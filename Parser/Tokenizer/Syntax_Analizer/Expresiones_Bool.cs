namespace BackEnd{
namespace Syntax_Analizer
{
    public partial class Syntax
    {

        private Node AndOr(Scope actualScope)
        {//Para que procese en caso de ser las expresiones booleanas unidas con & y |
            Node result = Bool_Op(actualScope);
            while (actual_token.Type == TokenType.And_Operator || actual_token.Type == TokenType.Or_Operator)
            {
                    if (actual_token.Type == TokenType.And_Operator)
                    {
                        int actualLine = actual_token.actualLine;
                        Eat(TokenType.And_Operator,"");
                        Node result1 = Bool_Op(actualScope);
                        result = new AndExpression(result,result1,NodeKind.Number,actualLine);
                    }
                    else if (actual_token.Type == TokenType.Or_Operator)
                    {
                        int actualLine = actual_token.actualLine;
                        Eat(TokenType.Or_Operator,"");
                        Node result1 = Bool_Op(actualScope);
                        result = new OrExpression(result,result1,NodeKind.Number,actualLine);
                    }
            }
            return result;
        }

        TokenType[] Bool_Oper =
        {
    TokenType.Equal_Operator,// ==
    TokenType.Distinct,// /!=
    TokenType.More_Than, //>
    TokenType.More_Equal_Than, //>=
    TokenType.Min_Than,// <
    TokenType.Min_Equal_Than// <=
    };

        private Node Bool_Op(Scope actualScope)
        {
            Node result = SumaResta(actualScope);
            int Operador = ItsBoolOp(actual_token.Type);
            //ItsBoolOp comprueba que tipo de operador es en el que estoy parado, para saber si es uno bool o no
            //Comprueba que sea alguno de los operadores booleanos
            /*
                0   ==
                1  /!=
                2  >
                3  >=
                4  <
                5  <=*/

            while (Operador < Bool_Oper.Length)
            {
                if (Operador == 0)
                {//operador ==
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.Equal_Operator,"");
                    Node result2 = SumaResta(actualScope);
                    result = new Igual(result,result2,actualLine);
                    Operador = ItsBoolOp(actual_token.Type);

                }

                else if (Operador == 1)
                {//operador !=
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.Distinct,"");
                    Node result2 = SumaResta(actualScope);
                    result = new Distinto(result,result2,actualLine);
                    Operador = ItsBoolOp(actual_token.Type);

                }
                else if (Operador == 2)
                {//operador >
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.More_Than,"");
                    Node result2 = SumaResta(actualScope);
                    result = new Mayor(result,result2,actualLine);
                    Operador = ItsBoolOp(actual_token.Type);
                }
                else if (Operador == 3)
                {//Operador >=
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.More_Equal_Than,"");
                    Node result2 = SumaResta(actualScope);
                    result = new MayorIgual(result,result2,actualLine);
                    Operador = ItsBoolOp(actual_token.Type);

                }
                else if (Operador == 4)
                {//Operador <
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.Min_Than,"");
                    Node result2 = SumaResta(actualScope);
                    result = new Menor(result,result2,actualLine);
                    Operador = ItsBoolOp(actual_token.Type);
                }
                else
                // (Operador == 5)
                {//Operador <=
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.Min_Equal_Than,"");
                    Node result2 = SumaResta(actualScope);
                    result = new Menor(result,result2,actualLine);
                    Operador = ItsBoolOp(actual_token.Type);
                }

            }
            return result;
        }

        int ItsBoolOp(TokenType Type)
        {
            for (int i = 0; i < Bool_Oper.Length; i++)
            {
                if (Type == Bool_Oper[i]) return i;
            }

            return Bool_Oper.Length;

        }
    }
}}