namespace BackEnd{
namespace Syntax_Analizer
{
    public partial class Syntax
    {
        public (Node,bool) WorkWithIdentifier(Scope actualScope)
        {
            Node result = null;
            bool asignation = false;
            int actualLine = actual_token.actualLine;
                Eat(TokenType.Identifier, "");
                string name = actual_token_value.ToString();
                //Hay varios casos, o es una constante, o una declaracion de funcion o es una instancia de funcion
                //O es una declaracion de constante
                if (IsNext(TokenType.LEFT_PARENTHESIS))
                {//Es un proceso relacionado con funcion
                    Eat(TokenType.LEFT_PARENTHESIS, "");
                    List<Node> RecieveExpression = new List<Node>();
                    HayBracket = true;
                    if (IsNext(TokenType.RIGHT_PARENTHESIS))
                    {
                        Eat(TokenType.RIGHT_PARENTHESIS, "");
                    }
                    else
                    {

                        // int totalConstants = 0;
                        // int totalReview = 0;

                        Node FunctionExpressions = BuildExpression(actualScope);//Expresiones recibidas

                        if (FunctionExpressions is null) Error("No se pueden hacer declaraciones en los argumentos");
                        else RecieveExpression.Add(FunctionExpressions);

                        while (actual_token.Type is TokenType.Comma)
                        {
                            Eat(TokenType.Comma, "");
                            FunctionExpressions = BuildExpression(actualScope);
                            if (FunctionExpressions is null) Error("No se pueden hacer declaraciones en los argumentos");
                            else RecieveExpression.Add(FunctionExpressions);
                        }
                        Eat(TokenType.RIGHT_PARENTHESIS, "");
                        HayBracket = false;
                    }

                    if (IsNext(TokenType.Asignation_Operator))
                    {//Es una declaracion de funcion
                        //Recordar para este punto que hay que revisar 1 si alguna funcion o variable fue agregada, porque eso esta mal
                        //Para este punto todo lo recibido deben haber sido nombres de variables
                        //3 en este caso si alguna expresion fue agregada a la lista de expresiones, xq si es 
                        //Una declaracion de funciones no debe recibir expresiones
                        Eat(TokenType.Asignation_Operator, "");

                        int inicio = position;
                        // Scope FunctionScope = BuildFunctionScope(actualScope,RecieveExpression);
                        
                        Function function = new Function(name);
                        actualScope.AddFunction(name,function);
                        Node BuilBody = BuildExpression(actualScope);
                        int final = position;
                        List<Token> TokensBody = new List<Token>();

                        for (int i = inicio; i < final; i++) TokensBody.Add(Token_Set[i]);
                        if(!IsNext(TokenType.Semicolon)) throw new Exception("Toda expresion debe terminar con punto y coma");
                        TokensBody.Add(actual_token);

                        actualScope.RemoveFUnction(name);
                        function = new Function(name,RecieveExpression, TokensBody, TokenType.nul,actualScope);
                        actualScope.AddFunction(name,function);
                    }
                    else
                    {

                        //Es una instancia de funcion
                        //En ninguno de los parametros recibidos se puede haber modificado el scope actual de la funcion
                        //No se pueden haber agregado ni variables, ni funciones nuevas
                        //SOlo debe haber sido modificada la lista de Expresiones
                        result = new FunctionCall(name,RecieveExpression,actualScope,actualLine);
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
                else if (IsNext(TokenType.Comma)&&!HayBracket)
                {// Es una expresion del tipo a,b,c = {Secuencia};
                    List<(string, int)> Constants = new List<(string, int)>();
                    Constants.Add((name, actualLine));
                    while (actual_token.Type == TokenType.Comma)
                    {
                        Eat(TokenType.Comma, "");
                        name = actual_token.Value.ToString();
                        actualLine = actual_token.actualLine;
                        Eat(TokenType.Identifier, "");
                        Constants.Add((name, actualLine));
                    }
                    Eat(TokenType.RIGHT_PARENTHESIS,"Se esperaba un )");
                    Eat(TokenType.Asignation_Operator, "Se esperaba un operador de asignacion");
                    Node ConstantsExpression = BuildExpression(actualScope);
                    for (int i = 0; i < Constants.Count; i++)
                    {
                        if (Constants[i].Item1.ToString() != "_")
                        {
                            if (i == Constants.Count - 1) actualScope.AddCOnstant(Constants[i].Item1, new AssignationSequences(i, true, ConstantsExpression, Constants[i].Item2));
                            else actualScope.AddCOnstant(Constants[i].Item1, new AssignationSequences(i, false, ConstantsExpression, Constants[i].Item2));
                        }
                    }

                }
                else
                {
                    result = new Constants(name, actualScope, actualLine);
                }
                return (result,asignation);
        }
    }
}}