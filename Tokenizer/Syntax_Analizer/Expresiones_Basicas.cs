using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml.XPath;

namespace Syntax_Analizer
{
    partial class Syntax
    {
        private Node LowExpression(Scope actualScope)
        {//Estas son las expresiones más bajas en la jerarquía

            Node result = null;
            bool asignation = false;
            if (actual_token.Type == TokenType.Number)
            {
                result = new BasicExpression(actual_token.Value, NodeKind.Number, actual_token.actualLine);
                Eat(TokenType.Number, "");
            }
            else if (actual_token.Type == TokenType.SUM_Operator)
            {//SOn las expresiones del tipo +Numero
                int actualLine = actual_token.actualLine;
                Eat(TokenType.SUM_Operator, "");
                result = new Mas(LowExpression(actualScope), actualLine);
                return result;
            }
            else if (actual_token.Type == TokenType.SUBSTRACTION_Operator)
            {//Son las expresiones del tipo -Numero
                int actualLine = actual_token.actualLine;
                Eat(TokenType.SUBSTRACTION_Operator, "");
                result = new Menos(LowExpression(actualScope), actualLine);

            }
            else if (actual_token.Type == TokenType.Quotes_Text)
            {//SOn las expresiones del tipo "un texto"
                result = new BasicExpression(actual_token, NodeKind.String, actual_token.actualLine);
                Eat(TokenType.Quotes_Text, "");
            }
            else if (actual_token.Value.ToString() == "if")
            {//Son las expresiones if-else
             //Que tienen la estructura if(expresion) expresion else expresion
             //Y de la que se guarda la posicion de la expresion después del else y después de analizada toda la expresion if-else  
                int actualLine = actual_token.actualLine;
                Eat(TokenType.Keyword, "");//if

                Eat(TokenType.LEFT_PARENTHESIS, "Despues de una expresion if se espera un parentesis izquierdo (");//Expresion condicional
                Node decision = BuildExpression(actualScope);
                //if (decision.Kind != NodeKind.Boolean) Error("Debe ir una expresion booleana"); Esto hay que arreglarlo
                Eat(TokenType.RIGHT_PARENTHESIS, "Se esperaba un parentesis derecho )");

                if (!(actual_token.Value.ToString() == "then")) Error("Se esperaba un then");
                Eat(TokenType.Keyword, "");//else
                Node result1 = BuildExpression(actualScope);//Expresion despues de la condicion

                if (!(actual_token.Value.ToString() == "else")) Error("Se esperaba un else");
                Eat(TokenType.Keyword, "");//else


                Node result2 = BuildExpression(actualScope);//Expresion despues del else

                //Por defecto siempre se va a pasar el tipo del resultado1
                result = new IfElse(decision, result1, result2, actualLine);

            }
            else if (actual_token.Type == TokenType.LEFT_PARENTHESIS)
            {
                // if(actual_token.Type!=TokenType.LEFT_PARENTHESIS) Error("No es una expresion válida");

                Eat(TokenType.LEFT_PARENTHESIS, "Se esperaba un (");
                result = BuildExpression(actualScope);
                Eat(TokenType.RIGHT_PARENTHESIS, "Se esperaba un )");
            }
            else if (actual_token.Type == TokenType.Let_Keyword)
            {
                int actualLine = actual_token.actualLine;
                Eat(TokenType.Let_Keyword, "");
                Scope LetScope = new Scope(actualScope);
                List<Node> LetExpressions = new List<Node>();
                while (actual_token.Type != TokenType.In_Keyword)
                {
                    Node EndExpression = BuildExpression(LetScope);
                    Eat(TokenType.Semicolon, "La expresión principal debe concluir con un punto y coma");
                    if (!(EndExpression is null)) LetExpressions.Add(EndExpression);
                    //Si es null es porque fue un caso en el que la accion fue void
                }
                Eat(TokenType.In_Keyword, "");
                Node returnExpression = BuildExpression(LetScope);
                result = new LetExpression(LetExpressions, returnExpression, actualLine);
            }
            else if (actual_token.Type == TokenType.Identifier)
            {
                int actualLine = actual_token.actualLine;
                Eat(TokenType.Identifier, "");
                string name = actual_token_value.ToString();
                //Hay varios casos, o es una constante, o una declaracion de funcion o es una instancia de funcion
                //O es una declaracion de constante
                if (IsNext(TokenType.LEFT_PARENTHESIS))
                {//Es un proceso relacionado con funcion
                    Scope FunctionScope = new Scope(actualScope);
                    Eat(TokenType.LEFT_PARENTHESIS, "");

                    int totalConstants = 0;
                    int totalReview = 0;
                    List<Node> RecieveExpression = new List<Node>();

                    Node FunctionExpressions = BuildExpression(FunctionScope);//Expresiones recibidas
                    if (FunctionExpressions is null) totalConstants++;
                    else RecieveExpression.Add(FunctionExpressions);
                    totalReview++;

                    while (actual_token.Type is TokenType.Comma)
                    {
                        Eat(TokenType.Comma, "");
                        FunctionExpressions = BuildExpression(FunctionScope);
                        if (FunctionExpressions is null) totalConstants++;
                        else RecieveExpression.Add(FunctionExpressions);
                        totalReview++;
                    }
                    Eat(TokenType.RIGHT_PARENTHESIS, "");

                    if (IsNext(TokenType.Asignation_Operator))
                    {//Es una declaracion de funcion
                        //Recordar para este punto que hay que revisar 1 si alguna funcion o variable fue agregada, porque eso esta mal
                        //Para este punto todo lo recibido deben haber sido nombres de variables
                        //3 en este caso si alguna expresion fue agregada a la lista de expresiones, xq si es 
                        //Una declaracion de funciones no debe recibir expresiones

                        int inicio = position;
                        Node BuilBody = BuildExpression(FunctionScope);
                        int final = position;
                        List<Token> TokensBody = new List<Token>();

                        for (int i = inicio; i < final; i++) TokensBody.Add(Token_Set[i]);
                        Function function = new Function(RecieveExpression, TokensBody, TokenType.nul);
                    }
                    else
                    {
                        //Es una instancia de funcion
                        //En ninguno de los parametros recibidos se puede haber modificado el scope actual de la funcion
                        //No se pueden haber agregado ni variables, ni funciones nuevas
                        //SOlo debe haber sido modificada la lista de Expresiones
                        //result = new CallFunction(name,RecieveExpression,FunctionScope,actualLine);

                    }

                }
                else if (IsNext(TokenType.Asignation_Operator))
                {//Es una creacion de una nueva variable
                    Eat(TokenType.Asignation_Operator, "");
                    asignation = true;
                    Node ExpresionAsociated = BuildExpression(actualScope);


                    //IMPORTANTE ARREGLAR LO DE AGREGAR LA LINEA DE ESTA ASIGNACION
                    actualScope.AddCOnstant(name, ExpresionAsociated);//Aqui tambien habria que decir en que linea se agrego la constante
                }
                else if (IsNext(TokenType.Comma))
                {// Es una expresion del tipo a,b,c = {Secuencia};
                    List<(string,int)> Constants = new List<(string,int)>();
                    Constants.Add((name,actualLine));
                    while (actual_token.Type == TokenType.Comma)
                    {
                        Eat(TokenType.Comma, "");
                        name = actual_token.Value.ToString();
                        actualLine = actual_token.actualLine;
                        Eat(TokenType.Identifier, "");
                        Constants.Add((name,actualLine));
                    }
                    Eat(TokenType.Asignation_Operator,"Se esperaba un operador de asignacion");
                    Node ConstantsExpression = BuildExpression(actualScope);
                    for(int i = 0; i<Constants.Count;i++)
                    {   if(i==Constants.Count-1) actualScope.AddCOnstant(Constants[i].Item1,new AssignationSequences(i,true,ConstantsExpression,Constants[i].Item2));
                        else actualScope.AddCOnstant(Constants[i].Item1,new AssignationSequences(i,false,ConstantsExpression,Constants[i].Item2));
                    }

                }
                else
                {
                    result = new Constants(name, actualScope, actualLine);
                }

            }
            else if (actual_token.Type == TokenType.LEFT_CURLYBRACES)
            {//Es una secuencia lo que tengo que crear
                result = BuildSequence(actualScope);
            }
            else if (result == null)
            {
                if (!asignation) Error("Unexpected token");
            }

            return result;

        }
        private Node BuildSequence(Scope actualScope)
        {
            Node result = null;
            int actualLine = actual_token.actualLine;
            Eat(TokenType.LEFT_CURLYBRACES, " ");
            List<Node> SequenceExpression = new List<Node>();
            Node ActualExpression = BuildExpression(actualScope);
            if (ActualExpression is null) throw new Exception("La secuencia solo recibe como valores expresiones");
            SequenceExpression.Add(ActualExpression);

            while (actual_token.Type == TokenType.Comma)
            {
                Eat(TokenType.Comma, "");
                ActualExpression = BuildExpression(actualScope);
                if (ActualExpression is null) throw new Exception("La secuencia solo recibe como valores expresiones");
                SequenceExpression.Add(ActualExpression);
            }
            if (IsNext(TokenType.TresPuntos))
            {
                Eat(TokenType.TresPuntos, "");
                if (IsNext(TokenType.RIGHT_CURLYBRACES))
                //Crea secuencia infinita
                {//{1...}
                 //{1,2,3,7,6 ...}
                    Eat(TokenType.RIGHT_CURLYBRACES, "");
                    result = new InfiniteNumericSequence(SequenceExpression, actualLine);
                }
                else
                {
                    //Crea secuencia finita, y crea una lista de numeros
                    //Secuencia finita generada{1,3,2 ... 9};
                    //{1 ... 9}
                    Node LastExpression = BuildExpression(actualScope);
                    SequenceExpression.Add(LastExpression);
                    Eat(TokenType.RIGHT_CURLYBRACES, "Se esperaba un cierre de la secuencia");
                    result = new FiniteSequence(SequenceExpression, true, actualLine);//Como es finita generada lleva true
                }
            }
            else
            {//{1,2,3,4};
                Eat(TokenType.RIGHT_CURLYBRACES, " ");
                result = new FiniteSequence(SequenceExpression, false, actualLine);
                //Como es finita pero no hay que generar nada pues lleva false

            }
            return result;
        }

    }

}

