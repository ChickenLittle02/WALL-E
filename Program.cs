// See https://aka.ms/new-console-template for more information
using System.Security;

Console.WriteLine("Hello, World!");
string codigo = "4+2-3";
var Prueba = new Tokenizer.Lexer(codigo);
Prueba.Show_TokenSet();