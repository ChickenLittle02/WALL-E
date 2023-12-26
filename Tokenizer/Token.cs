public enum TokenType
{
    Number, //todos los valores numericos
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
    Function_Keyword, //function
    Let_Keyword,//let
    In_Keyword,//in
    If_Keyword,//if
    ThenKeyword,//then
    ElseKeyword,//Else
    Boolean,// true, false
    Comma, //,
    Semicolon, //;
    BreakLine,// \n
    Quotes_Text, // "mm"
    Blank_Space,// " "
    nul,
    None,
}



public class Token
{
    public TokenType Type { get; set; }
    public object Value { get; set; }

    public Token(TokenType type, object value)
    {
        Type = type;
        Value = value;
    }
    public void Show()
    {
        System.Console.WriteLine("(" + Type + "," + Value + ")");
    }
}