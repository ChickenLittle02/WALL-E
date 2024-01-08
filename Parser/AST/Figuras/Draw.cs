using System.Runtime.CompilerServices;
using Microsoft.JSInterop;

namespace BackEnd
{
    public class ForDraw
    {
        public static IJSRuntime _jsRuntime ;
        public static string Code { get; private set; }
        public static string Console { get; private set; }
        public static void SetRuntime(IJSRuntime jsRuntime, string code)
        {
            _jsRuntime = jsRuntime;
            Code = code;
            Start();
        }

        public static void Start()
        {
            BackEnd.Lexer_Analizer.Tokenizer Prueba = new BackEnd.Lexer_Analizer.Tokenizer(Code);
            Prueba.Start();
            var Syntaxis = new BackEnd.Syntax_Analizer.Syntax(Prueba.TokenSet);
            Syntaxis.Start();
            foreach (var item in Syntaxis.NodesLines) item.CheckSemantic();
            string resultado = "";
            foreach (var item in Syntaxis.NodesLines)
            {
                item.Evaluate();
                if (item is not Draw)
                {
                    resultado += item.Value.ToString() + "\n";
                }
            }
            Console = resultado;
        }

    }

}