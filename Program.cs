// See https://aka.ms/new-console-template for more information
using System.Security;
using Lexer_Analizer;

// Console.WriteLine("Hello, World!");
// string codigo = "4+2-3";
// var Prueba = new Tokenizer.Lexer(codigo);
// Prueba.Show_TokenSet();




string prueba = "4+2-3*2+10^2%2;";

Code Codigo = Import.GetDocuments(@"C:\RUBEN\HULK\WALL-E\Codigos\Prueba.txt");//Hay que arreglar que aqui la ruta se encuentre sola
Tokenizer Syntax = new Tokenizer(Codigo.Text);
Syntax.Start();
Syntax_Analizer.Syntax Syntaxis = new Syntax_Analizer.Syntax(Syntax.TokenSet);
Syntaxis.Start();
foreach(var item in Syntaxis.NodesLines)
{
    item.CheckSemantic();
}
foreach(var item in Syntaxis.NodesLines)
{
    item.Evaluate();
    System.Console.WriteLine(item);
}