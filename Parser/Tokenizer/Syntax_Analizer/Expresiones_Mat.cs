namespace BackEnd{
namespace Syntax_Analizer
{
    public partial class Syntax
    {

        private Node SumaResta(Scope actualScope)
        {
            Node result = MultiplicaDivide(actualScope);
            while (actual_token.Type == TokenType.SUM_Operator || actual_token.Type == TokenType.SUBSTRACTION_Operator)
            {//COmprueba que este sumando y restando tipos numericos

                if (actual_token.Type == TokenType.SUM_Operator)
                {
                    //if (result.Kind!= NodeKind.Number) Error("Antes de un simbolo de + se espera un tipo number");
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.SUM_Operator,"");
                    Node result2 = MultiplicaDivide(actualScope);
                    //if (result2.Kind!= NodeKind.Number) Error("Despues de un simbolo de + se espera un tipo number");
                    result = new Suma(result,result2,actualLine);
                }
                else if (actual_token.Type == TokenType.SUBSTRACTION_Operator)
                {

                    //if (!(result.Kind is NodeKind.Number)) Error("Antes de un simbolo de - se espera un tipo number");
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.SUBSTRACTION_Operator,"");
                    Node result2 = MultiplicaDivide(actualScope);
                    //if (!(result2.Kind is NodeKind.Number)) Error("Despues de un simbolo de - se espera un tipo number");
                    result = new Resta(result,result2,actualLine);
                }
            }
            return result;
        }

        private Node MultiplicaDivide(Scope actualScope)
        {
            Node result = Pow(actualScope);

            while (actual_token.Type == TokenType.MULT_Operator || actual_token.Type == TokenType.DIV_Operator)
            {//Comprueba que este multiplicando y dividiendo tipos numericos

                if (actual_token.Type == TokenType.MULT_Operator)
                {
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.MULT_Operator,"");
                    Node result2 = Pow(actualScope);
                    result = new Multiplicacion(result,result2,actualLine);
                }
                if (actual_token.Type == TokenType.DIV_Operator)
                {
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.DIV_Operator,"");
                    Node result2 = Pow(actualScope);
                    result = new Division(result,result2,actualLine);
                }
            }
            return result;
        }
        private Node Pow(Scope actualScope)
        {//COmprueba que en caso de que el operador sea el de potencia, el token con el que se esta evaluando sea numerico
            Node result = Rest(actualScope);
            if (actual_token.Type == TokenType.POW_Operator)
            {
                int actualLine = actual_token.actualLine;
                Eat(TokenType.POW_Operator,"");

                Node result2 = Pow(actualScope);
                result = new Potencia(result,result2,actualLine);
            }
            //SI entra al if y sale sin problemas es porque el tipo de result es Numb, y si no, el tipo es cualquier otro
            return result;
        }
        private Node Rest(Scope actualScope)
        {//COmprueba que en caso de que el operador sea el de calcular resto, el token con el que se esta evaluando sea numerico
            Node result = LowExpression(actualScope);
            if (actual_token.Type == TokenType.REST_Operator)
            {
                int actualLine = actual_token.actualLine;
                Eat(TokenType.REST_Operator,"");

                Node result2 = LowExpression(actualScope);
                result = new Resto(result,result2,actualLine);
            }
            //SI entra al if y sale sin problemas es porque el tipo de result es Numb, y si no, el tipo es cualquier otro
            return result;
        }

    }
}}