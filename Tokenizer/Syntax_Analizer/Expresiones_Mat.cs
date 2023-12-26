namespace Syntax_Analizer
{
    partial class Syntax
    {

        private Node SumaResta()
        {
            Node result = MultiplicaDivide();
            while (actual_token.Type == TokenType.SUM_Operator || actual_token.Type == TokenType.SUBSTRACTION_Operator)
            {//COmprueba que este sumando y restando tipos numericos

                if (actual_token.Type == TokenType.SUM_Operator)
                {
                    if (result.Kind!= NodeKind.Number) Error("Antes de un simbolo de + se espera un tipo number");
                    Eat(TokenType.SUM_Operator,"");
                    Node result2 = MultiplicaDivide();
                    if (result2.Kind!= NodeKind.Number) Error("Despues de un simbolo de + se espera un tipo number");
                    result = new Suma(result,result2);
                }
                else if (actual_token.Type == TokenType.SUBSTRACTION_Operator)
                {

                    if (!(result.Kind is NodeKind.Number)) Error("Antes de un simbolo de - se espera un tipo number");
                    Eat(TokenType.SUBSTRACTION_Operator,"");
                    Node result2 = MultiplicaDivide();
                    if (!(result2.Kind is NodeKind.Number)) Error("Despues de un simbolo de - se espera un tipo number");
                    result = new Resta(result,result2);
                }
            }
            return result;
        }

        private Node MultiplicaDivide()
        {
            Node result = Pow();

            while (actual_token.Type == TokenType.MULT_Operator || actual_token.Type == TokenType.DIV_Operator)
            {//Comprueba que este multiplicando y dividiendo tipos numericos

                if (actual_token.Type == TokenType.MULT_Operator)
                {
                    if (!(result.Kind is NodeKind.Number)) Error("Antes de un simbolo de * se espera un tipo number");
                    Eat(TokenType.MULT_Operator,"");
                    Node result2 = Pow();
                    if (!(result2.Kind is NodeKind.Number)) Error("Despues de un simbolo de * se espera un tipo number");
                    result = new Multiplicacion(result,result2);
                }
                if (actual_token.Type == TokenType.DIV_Operator)
                {
                    if (!(result.Kind is NodeKind.Number)) Error("Antes de un simbolo de / se espera un tipo number");
                    Eat(TokenType.DIV_Operator,"");
                    Node result2 = Pow();
                    if (!(result2.Kind is NodeKind.Number)) Error("Despues de un simbolo de / se espera un tipo number");
                    result = new Division(result,result2);
                }
            }
            return result;
        }
        private Node Pow()
        {//COmprueba que en caso de que el operador sea el de potencia, el token con el que se esta evaluando sea numerico
            Node result = Rest();
            if (actual_token.Type == TokenType.POW_Operator)
            {
                if (!(result.Kind is NodeKind.Number)) Error("Antes de un simbolo de ^ se espera un tipo number");
                Eat(TokenType.POW_Operator,"");

                Node result2 = Pow();
                if (!(result2.Kind is NodeKind.Number)) Error("Despues de un simbolo de ^ se espera un tipo number");
                result = new Potencia(result,result2);
            }
            //SI entra al if y sale sin problemas es porque el tipo de result es Numb, y si no, el tipo es cualquier otro
            return result;
        }
        private Node Rest()
        {//COmprueba que en caso de que el operador sea el de calcular resto, el token con el que se esta evaluando sea numerico
            Node result = LowExpression();
            if (actual_token.Type == TokenType.REST_Operator)
            {
                if (!(result.Kind is NodeKind.Number)) Error("Antes de un simbolo de % se espera un tipo number");
                Eat(TokenType.REST_Operator,"");

                Node result2 = LowExpression();
                if (!(result2.Kind is NodeKind.Number)) Error("Despues de un simbolo de % se espera un tipo number");
                result = new Resto(result,result2);
            }
            //SI entra al if y sale sin problemas es porque el tipo de result es Numb, y si no, el tipo es cualquier otro
            return result;
        }

    }
}