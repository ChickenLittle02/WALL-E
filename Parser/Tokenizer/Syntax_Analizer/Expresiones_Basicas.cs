namespace BackEnd{
namespace Syntax_Analizer
{
    public partial class Syntax
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
            else if (actual_token.Type == TokenType.Undefined)
            {
                result = new UndefinedSequence(actual_token.actualLine);
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

                Node decision = BuildExpression(actualScope);
                //if (decision.Kind != NodeKind.Boolean) Error("Debe ir una expresion booleana"); Esto hay que arreglarlo
                
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
                Console.WriteLine("Llego aqui");
                Eat(TokenType.In_Keyword, "");
                Node returnExpression = BuildExpression(LetScope);
                result = new LetExpression(LetExpressions, returnExpression, actualLine);
            }
            else if (actual_token.Type == TokenType.Identifier)
            {
                (Node,bool) Id = WorkWithIdentifier(actualScope);
                result = Id.Item1;
                asignation = Id.Item2;

            }
            else if (actual_token.Type == TokenType.LEFT_CURLYBRACES)
            {//Es una secuencia lo que tengo que crear
                result = BuildSequence(actualScope);
            }else if(actual_token.Type == TokenType.Keyword)
            {
                (Node,bool) Id = WorkWithKeywords(actualScope);
                result = Id.Item1;
                asignation = Id.Item2;
            }
            else if (result == null)
            {
                if (!asignation) Error("Unexpected token");
            }

            return result;

        }
        private Scope BuildFunctionScope(Scope functionScope, List<Node> Constants)
        {
            functionScope = new Scope(functionScope);
            for(int i = 0; i<Constants.Count;i++)   functionScope.AddCOnstant(((Constants)Constants[i]).name,null);
            return functionScope;

        }
        private Node BuildSequence(Scope actualScope)
        {
            Node result = null;
            int actualLine = actual_token.actualLine;
            Eat(TokenType.LEFT_CURLYBRACES, " ");
            List<Node> SequenceExpression = new List<Node>();
            HayBracket = true;
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
                    HayBracket = false;
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
                    HayBracket = false;
                    result = new FiniteSequence(SequenceExpression, true, actualLine);//Como es finita generada lleva true
                }
            }
            else
            {//{1,2,3,4};
                Eat(TokenType.RIGHT_CURLYBRACES, " ");
                HayBracket = false;
                result = new FiniteSequence(SequenceExpression, false, actualLine);
                //Como es finita pero no hay que generar nada pues lleva false

            }
            return result;
        }

    }

}

}