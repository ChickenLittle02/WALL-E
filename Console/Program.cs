// See https://aka.ms/new-console-template for more information
using System.Security;
using BackEnd;
using BackEnd.Lexer_Analizer;
using BackEnd.Syntax_Analizer;

// Console.WriteLine("Hello, World!");
// string codigo = "4+2-3";
// var Prueba = new Tokenizer.Lexer(codigo);
// Prueba.Show_TokenSet();




string prueba = "let a = 5; in a+2;";

Tokenizer Syntax = new Tokenizer(prueba);
Syntax.Start();
var Syntaxis = new BackEnd.Syntax_Analizer.Syntax(Syntax.TokenSet);
Syntaxis.Start();
foreach (var item in Syntaxis.NodesLines)
{
    item.CheckSemantic();
}
foreach (var item in Syntaxis.NodesLines)
{
    item.Evaluate();
    System.Console.WriteLine(item);
}