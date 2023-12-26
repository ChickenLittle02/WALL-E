namespace Syntax_Analizer
{
    partial class Syntax
    {
        private Node LowExpression()
        {//Estas son las expresiones más bajas en la jerarquía
            Node result = null;
            if (actual_token.Type == TokenType.BreakLine)
            {
                actual_line++;
                Eat(TokenType.BreakLine, "");
                HayBreakLine = true;
                result = LowExpression();
                HayBreakLine = false;

            }
            else if (actual_token.Type == TokenType.Number)
            {
                result = new BasicExpression(actual_token);
                Eat(TokenType.Number, "");
            }
            else if (actual_token.Type == TokenType.SUM_Operator)
            {//SOn las expresiones del tipo +Numero
                Eat(TokenType.SUM_Operator, "");
                result = new Mas(LowExpression());
                if (result.Kind != NodeKind.Number) Error("Despues del operador + se espera un tipo Number");
                return result;
            }
            else if (actual_token.Type == TokenType.SUBSTRACTION_Operator)
            {//Son las expresiones del tipo -Numero
                Eat(TokenType.SUBSTRACTION_Operator, "");
                result = new Menos(LowExpression());
                if (result.Kind != NodeKind.Number) Error("Despues del operador - se espera un tipo Number");

            }
            else if (actual_token.Type == TokenType.Quotes_Text)
            {//SOn las expresiones del tipo "un texto"
                result = new BasicExpression(actual_token);
                Eat(TokenType.Quotes_Text, "");
            }
            else if (actual_token.Value.ToString() == "if")
            {//Son las expresiones if-else
             //Que tienen la estructura if(expresion) expresion else expresion
             //Y de la que se guarda la posicion de la expresion después del else y después de analizada toda la expresion if-else  
                Eat(TokenType.Keyword, "");//if

                Eat(TokenType.LEFT_PARENTHESIS, "Despues de una expresion if se espera un parentesis izquierdo (");//Expresion condicional
                Node decision = Expression();
                if (decision.Kind != NodeKind.Boolean) Error("Debe ir una expresion booleana");
                Eat(TokenType.RIGHT_PARENTHESIS, "Se esperaba un parentesis derecho )");

                if (!(actual_token.Value.ToString() == "then")) Error("Se esperaba un then");
                Eat(TokenType.Keyword, "");//else
                Node result1 = Expression();//Expresion despues de la condicion

                if (!(actual_token.Value.ToString() == "else")) Error("Se esperaba un else");
                Eat(TokenType.Keyword, "");//else


                Node result2 = Expression();//Expresion despues del else

                //Por defecto siempre se va a pasar el tipo del resultado1
                result = new IfElse(decision, result1, result2);

            }else if(actual_token.Type==TokenType.LEFT_PARENTHESIS){
                // if(actual_token.Type!=TokenType.LEFT_PARENTHESIS) Error("No es una expresion válida");

                Eat(TokenType.LEFT_PARENTHESIS,"Se esperaba un (");
                result = Expression();
                Eat(TokenType.RIGHT_PARENTHESIS,"Se esperaba un )");
            }
            else if (result == null)
            {
                if (!HayBreakLine) Error("Unexpected token");
            }

            return result;
            // else if (actual_token.Type == TokenType.Let_Keyword)
            // {//Son las expresiones let-in
            //  //Que tienen la forma let variable1 = expresion, variable2 = expresion, ..., variableN = expresion in expresion
            //  //Donde cada variable solo existe dentro del let-in por tanto hay que agregarlas al diccionario de variables
            //  //Y al terminar de porcesarlas eliminarlas del diccionario con variables 
            //     Eat(TokenType.Let_Keyword,"");
            //     Dictionary<string, TokenType> Var_Subset = Variables_Subset();
            //     Variables_Set.Add(Var_Subset);
            //     variable_subset++;
            //     Eat(TokenType.In_Keyword,"Se esperaba un in");
            //     TokenType result = Expression();
            //     Variables_Set.RemoveAt(variable_subset);
            //     variable_subset--;
            //     return result;

            // }
            // else if (actual_token.Type == TokenType.Not_Operator)
            // {//El operador bool de negacion, !
            //     Eat(TokenType.Not_Operator,"");
            //     Node result = Expression();
            //     if (!(result == TokenType.Boolean) && result != TokenType.nul) Error("No se puede aplicar el operador ! a un tipo " + result.GetType());
            //     return result;

            // }
            // else if (actual_token.Type == TokenType.Identifier)
            // {
            //     Eat(TokenType.Identifier,"");
            //     //Comprobar si es una funcion
            //     if (IsNext(TokenType.LEFT_PARENTHESIS))
            //     {
            //         //Es porque es una funcion
            //         string function_name = actual_token_value.ToString();
            //         bool Existence1 = Check_Function_Existence();
            //         if (!Existence1) Error("Esta funcion no existe");

            //         TokenType result = Choosing_Function(function_name);

            //         return result;
            //     }
            //     //si no es una funcion entonces es una variable
            //     (TokenType, bool) Existence = Check_Var_Existence();
            //     if (!Existence.Item2) Error("La variable no existe en este entorno");
            //     return Existence.Item1;

            // }
            // else if(actual_token.Type == TokenType.Keyword)
            // {//Aqui solo
            //     if (actual_token.Value.ToString() == "else") Error("Todo else debe estar precedido de un if");
            //     if (actual_token.Value.ToString() == "in") Error("Todo in debe estar precedido de un let");

            //     Eat(TokenType.Keyword,"");
            //     string function_name = actual_token_value.ToString();
            //         bool Existence1 = Check_Function_Existence();
            //         if (!Existence1) Error("Esta funcion no existe");

            //         TokenType result = Choosing_Function(function_name);

            //         return result;


            // }
            // else 
            // 

        }


        // private Dictionary<string, TokenType> Variables_Subset()
        // {
        //     Dictionary<string, TokenType> Var_Set = new Dictionary<string, TokenType>();

        //     (string, TokenType) Var = Variable();
        //     Var_Set.Add(Var.Item1, Var.Item2);

        //     while (actual_token.Type == TokenType.Comma)
        //     {
        //         Eat(TokenType.Comma,"");
        //         Var = Variable();
        //         Var_Set.Add(Var.Item1, Var.Item2);
        //     }

        //     return Var_Set;
        // }

        // private (string, TokenType) Variable()
        // {
        //     Eat(TokenType.Identifier,"Se esperaba un nombre de variable");
        //     string variable_name = actual_token_value.ToString();
        //     Eat(TokenType.Asignation_Operator,"Se esperaba un =");

        //     TokenType value = Expression();
        //     return (variable_name, value);

        // }

        // (TokenType, bool) Check_Var_Existence()
        // {//Comprueba por cada posicion del diccionario de variables si la variable existe

        //     for (int i = variable_subset; i >= 0; i--)
        //     {

        //         if (Variables_Set[i].ContainsKey(actual_token_value.ToString()))
        //         {
        //             return (Variables_Set[i][actual_token_value.ToString()], true);
        //         }

        //     }
        //     return (TokenType.nul, false);
        // }

    }
}