// See https://aka.ms/new-console-template for more information
using System.Security;
using BackEnd;
using BackEnd.Lexer_Analizer;
using BackEnd.Syntax_Analizer;

// Console.WriteLine("Hello, World!");
// string codigo = "4+2-3";
// var Prueba = new Tokenizer.Lexer(codigo);
// Prueba.Show_TokenSet();




string prueba = @"


{1,2,3,5,6};
{1,2,3 ...};
{1,4,6,8,9 ... 12};


a={};
b,c,_=a;
print b;
if a then 1 else 2;

d,e,f={1,6,7,34};
print d+e;
g,h,_=f;
print g+h;";

BackEnd.ForDraw.Colors = new Stack<string>();
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