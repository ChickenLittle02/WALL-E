namespace BackEnd{
namespace Syntax_Analizer
{
    public partial class Syntax
    {
        List<Token> Token_Set { get; set; }
        public List<Node> NodesLines {get; private set;}
        Token actual_token { get; set; }
        object actual_token_value { get; set; }
        private int position { get; set; }
        int size { get; set; }
        private bool HayBracket{get; set;}

        private Scope FirstScope{get; set;}
        

        // bool EstoyAnalizando { get; set; }//Esto es para cuando vaya a analizar sintacticamente el cuerpo de una funcion
        // List<Dictionary<string, TokenType>> Variables_Set { get; set; }
        // Dictionary<string, Function> New_Functions { get; set; }
        // //Aqui se encuentran todas las funciones agregadas
        // List<string> System_Function = new List<string> {"print", "sqrt", "cos", "sin", "exp", "log", "rand" };
        // //Las funciones del sistema
        // int variable_subset { get; set; }

        public Syntax(List<Token> token_Set)
        {
            Token_Set = token_Set;
            position = 0;
            FirstScope = null;
            size = Token_Set.Count();
            NodesLines = new List<Node>();
            HayBracket = false;
            if (position != size)
            {
                actual_token = Token_Set[position];
            }
            else
            {
                actual_token = null;
            }
        }

        public Syntax(List<Token> token_Set, Scope firstScope)
        {
            //Este constructor solo se utiliza en el casos en que voy a procesar la funcion, 
            //que necesito que reciba las variables,
            // las funciones que existen, y 
            Token_Set = token_Set;
            position = 0;
            size = Token_Set.Count();
            HayBracket = false;
            
            NodesLines = new List<Node>();
            FirstScope = firstScope;

            if (position != size)
            {
                actual_token = Token_Set[position];
            }
            else
            {
                actual_token = null;
            }
        }




        private void Error(string message)
        {
            throw new Exception("Syntax error en token " + actual_token.Value + " : " + message);
        }



        public void Start()
        {
            Scope scope = new Scope(FirstScope);
            while(position<size-1)
            {
            Node EndExpression = BuildExpression(scope);
            Eat(TokenType.Semicolon, "La expresión principal debe concluir con un punto y coma");
            if(!(EndExpression is null)) NodesLines.Add(EndExpression);
            //Si es null es porque fue un caso en el que la accion fue void
            
            }
            

        }

        public Node BuildExpression(Scope actualScope) => AndOr(actualScope);


        private void Eat(TokenType Type, string message)
        {
            if (Type == actual_token.Type)
            {
                actual_token_value = actual_token.Value;
                GetNextToken();
            }
            else
            {
                Error(message);
            }
        }

        private void GetNextToken()
        {

            if (position >= size - 1)
            {
                actual_token = new Token(TokenType.None, " ",actual_token.actualLine);
                position++;
            }
            else
            {
                position++;
                actual_token = Token_Set[position];
            }

        }

        private bool IsNext(TokenType Expected_Type)
        {
            return actual_token.Type == Expected_Type;
        }

        // private void AddSystemVariables()
        // {
        //     Dictionary<string,TokenType> SystemVars = new Dictionary<string, TokenType>();
        //     SystemVars.Add("PI",TokenType.Number);
        //     Variables_Set.Add(SystemVars);
        //     variable_subset++;

        // }


    }
}
}