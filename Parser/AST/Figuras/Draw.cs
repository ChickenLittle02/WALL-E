using System.Runtime.CompilerServices;
using Microsoft.JSInterop;

namespace BackEnd
{
    public class ForDraw
    {
        public static IJSRuntime _jsRuntime;
        public static int canvasWidth;
        public static int canvasHeight;
        public static Stack<string> Colors;
        public static string Code { get; private set; }
        public static string Console { get; private set; }
        public static void SetCanvasProperties(int width, int height)
        {
            canvasWidth = width;
            canvasHeight = height;
        }
        public static void SetRuntime(IJSRuntime jsRuntime, string code)
        {
            _jsRuntime = jsRuntime;
            Code = code;
            Start();
        }
        public static string GetColor()
        {
            if (Colors.Count != 0) return Colors.Peek();
            else return "black";
        }

        public static void Start()
        {
            // try {
                
            Colors = new Stack<string>();
            BackEnd.Lexer_Analizer.Tokenizer Prueba = new BackEnd.Lexer_Analizer.Tokenizer(Code);
            Prueba.Start();
            if (Prueba.TokenSet.Count != 0)
            {
                var Syntaxis = new BackEnd.Syntax_Analizer.Syntax(Prueba.TokenSet);
                Syntaxis.Start();
                if (Error.diagnostics.Count == 0)
                {
                    foreach (var item in Syntaxis.NodesLines) item.CheckSemantic();
                    if (Error.diagnostics.Count == 0)
                    {
                        string resultado = "";
                        foreach (var item in Syntaxis.NodesLines)
                        {
                            if (Error.diagnostics.Count == 0)
                            {
                                item.Evaluate();
                                if (item is Print)
                                {
                                    resultado += item.Value.ToString() + "\n";
                                }
                            }
                            else break;
                        }
                        if (Error.diagnostics.Count == 0)
                        {
                            Console = resultado;
                        }
                        else Console = Error.GetErrors();
                    }
                    else
                    {
                        Console = Error.GetErrors();
                    }
                }
                else
                {
                    Console = Error.GetErrors();
                }
            }
        }

    }

}