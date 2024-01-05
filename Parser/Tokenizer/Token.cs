namespace BackEnd{
public enum TokenType
{
    Number, //todos los valores numericos
    SequenceKeyword,
    ColorKeyword,
    Color,//Para definir los colores
    TresPuntos,//...
    SUM_Operator,//+
    SUBSTRACTION_Operator,//-
    REST_Operator,//%
    MULT_Operator,//*
    DIV_Operator, // /
    POW_Operator,//^
    Asignation_Operator,// =
    Equal_Operator,// ==
    Distinct,// /!=
    More_Than, //>
    More_Equal_Than, //>=
    Min_Than,// <
    Min_Equal_Than,// <=
    Arrow, //=>
    And_Operator,// &
    Or_Operator,// |
    RIGHT_PARENTHESIS,// (
    LEFT_PARENTHESIS,// )
    RIGHT_CURLYBRACES,// {
    LEFT_CURLYBRACES,// }
    Not_Operator,// /!
    Identifier, // todos los nombres
    Keyword, //Las palabras reservadas, number, string, bool, let, in, 
    Let_Keyword,//let
    In_Keyword,//in
    If_Keyword,//if
    ThenKeyword,//then
    ElseKeyword,//else
    Undefined,
    Boolean,// true, false
    Comma, //,
    Semicolon, //;
    Quotes_Text, // "mm"
    Blank_Space,// " "
    nul,
    None,
}



public class Token
{
    public TokenType Type { get; set; }
    public object Value { get; set; }
    public int actualLine{get; set;}

    public Token(TokenType type, object value, int ActualLine)
    {
        Type = type;
        Value = value;
        actualLine = ActualLine;
    }
    public void Show()
    {
        System.Console.WriteLine("(" + Type + "," + Value + ")"+" line "+actualLine);
    }
}}