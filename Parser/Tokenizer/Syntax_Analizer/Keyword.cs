using System.Xml.XPath;

namespace BackEnd
{

    namespace Syntax_Analizer
    {
        public partial class Syntax
        {
            public (Node, bool) WorkWithKeywords(Scope actualScope)
            {
                string name = actual_token.Value.ToString();
                int actualLine = actual_token.actualLine;
                Node result = null;
                bool IsDeclaration = false;
                if (name == "print") result = Print(actualScope);
                else if (name == "draw")
                {
                    Eat(TokenType.Keyword);
                    string FiguraId = "";
                    if (IsNext(TokenType.Quotes_Text))
                    {
                        FiguraId = actual_token.Value.ToString();
                    }
                    result = new Draw(FiguraId, BuildExpression(actualScope), actualLine);
                }
                else if (name == "point")
                {
                    (Node, bool) Value = InstanciaPunto(actualScope);
                    result = Value.Item1;
                    IsDeclaration = Value.Item2;
                }
                else if (name == "line" || name == "ray" || name == "segment")
                {
                    (Node, bool) Value = InstanciaLinea(name, actualScope);
                    result = Value.Item1;
                    IsDeclaration = Value.Item2;
                }
                else if (name == "intersect")
                {
                    result = Intersect(actualScope);
                }
                else if (name == "arc")
                {
                    (Node, bool) Value = InstanciaArco(actualScope);
                    result = Value.Item1;
                    IsDeclaration = Value.Item2;
                }

                else if (name == "circle")
                {
                    (Node, bool) Value = InstanciaCircunferencia(actualScope);
                    result = Value.Item1;
                    IsDeclaration = Value.Item2;
                }
                else if (name == "color")
                {
                    Eat(TokenType.Keyword);
                    string color = actual_token.Value.ToString();
                    Eat(TokenType.Identifier, "Se esperaba un identificador de color");
                    result = new Color(color, actualLine);
                }
                else if (name == "restore")
                {
                    Eat(TokenType.Keyword);
                    result = new Restore(actualLine);
                }

                return (result, IsDeclaration);

            }
            public Node Intersect(Scope actualScope)
            {
                int actualLine = actual_token.actualLine;
                Eat(TokenType.Keyword);

                //Significa que es la funcion intersect(1,2);
                HayBracket = true;
                List<Node> PointExpression = new List<Node>();
                Eat(TokenType.LEFT_PARENTHESIS);
                HayBracket = true;
                Node Expression = BuildExpression(actualScope);
                PointExpression.Add(Expression);
                while (actual_token.Type is TokenType.Comma)
                {
                    Eat(TokenType.Comma);
                    Expression = BuildExpression(actualScope);
                    PointExpression.Add(Expression);
                }
                Eat(TokenType.RIGHT_PARENTHESIS);
                HayBracket = false;
                if (PointExpression.Count != 2) new Error(ErrorKind.Semantic,"La funcion intersect recibe solo dos parametros",actualLine);
                Node result = new IntersectionFunction(PointExpression[0], PointExpression[1], actualLine);
                return result;
            }
            public (Node, bool) InstanciaPunto(Scope actualScope)
            {
                Node result = null;
                bool IsDeclaration = false;
                int actualLine = actual_token.actualLine;
                Eat(TokenType.Keyword, "");
                if (IsNext(TokenType.SequenceKeyword))
                {//Es point sequence prueba aqui prueba es un tipo secuencia de puntos

                }
                else if (IsNext(TokenType.LEFT_PARENTHESIS))
                {
                    //Significa que es la funcion punto point(1,2);
                    Eat(TokenType.LEFT_PARENTHESIS, "");
                    HayBracket = true;
                    List<Node> PointExpression = new List<Node>();
                    Node Expression = BuildExpression(actualScope);
                    PointExpression.Add(Expression);
                    while (actual_token.Type is TokenType.Comma)
                    {
                        Eat(TokenType.Comma, "");
                        Expression = BuildExpression(actualScope);
                        PointExpression.Add(Expression);
                    }
                    Eat(TokenType.RIGHT_PARENTHESIS, "");
                    HayBracket = false;
                    if (PointExpression.Count != 2) new Error(ErrorKind.Semantic,"point function only recieve two parameters",actualLine);
                    result = new PointFunction(PointExpression[0], PointExpression[1], actualLine);
                }
                else
                {
                    //Tiene que ser un identificador point p1;
                    string name = actual_token.Value.ToString();
                    Eat(TokenType.Identifier, " Expected an ID after point");
                    actualScope.AddCOnstant(name, new Punto(actualLine));
                    IsDeclaration = true;
                }
                return (result, IsDeclaration);

            }
            public (Node, bool) InstanciaLinea(string tipo, Scope actualScope)
            {
                Node result = null;
                int actualLine = actual_token.actualLine;
                bool IsDeclaration = false;
                Eat(TokenType.Keyword, "");
                if (IsNext(TokenType.SequenceKeyword))
                {//Es point sequence prueba aqui prueba es un tipo secuencia de puntos

                }
                else if (IsNext(TokenType.LEFT_PARENTHESIS))
                {
                    Eat(TokenType.LEFT_PARENTHESIS, "");
                    HayBracket = true;
                    List<Node> PuntosParaCrearLinea = new List<Node>();
                    Node ExpresionesParaLineas = BuildExpression(actualScope);
                    PuntosParaCrearLinea.Add(ExpresionesParaLineas);
                    while (actual_token.Type == TokenType.Comma)
                    {
                        Eat(TokenType.Comma, "");
                        ExpresionesParaLineas = BuildExpression(actualScope);
                        PuntosParaCrearLinea.Add(ExpresionesParaLineas);
                    }
                    Eat(TokenType.RIGHT_PARENTHESIS, "");
                    HayBracket = false;
                    if (PuntosParaCrearLinea.Count != 2) new Error(ErrorKind.Semantic,"line function only recieve two parameters",actualLine);
                    if (tipo is "line") result = new SystemFunction(new Line(PuntosParaCrearLinea[0], PuntosParaCrearLinea[1], actualLine), actualLine);
                    else if (tipo is "segment") result = new SystemFunction(new Segment(PuntosParaCrearLinea[0], PuntosParaCrearLinea[1], actualLine), actualLine);
                    else result = new SystemFunction(new Ray(PuntosParaCrearLinea[0], PuntosParaCrearLinea[1], actualLine), actualLine);
                    //tipo is "ray"

                }
                else
                {
                    //TIene que ser un identificador line p1;
                    string name = actual_token.Value.ToString();
                    actualLine = actual_token.actualLine;
                    Eat(TokenType.Identifier, " Expected an ID after line");
                    if (tipo is "line") actualScope.AddCOnstant(name, new Line(actualLine));
                    else if (tipo is "segment") actualScope.AddCOnstant(name, new Segment(actualLine));
                    else //if(tipo is "line") 
                        actualScope.AddCOnstant(name, new Ray(actualLine));
                    IsDeclaration = true;

                }
                return (result, IsDeclaration);

            }
            public (Node, bool) InstanciaArco(Scope actualScope)
            {

                Node result = null;
                int actualLine = actual_token.actualLine;
                bool IsDeclaration = false;
                Eat(TokenType.Keyword, "");
                if (IsNext(TokenType.SequenceKeyword))
                {//Es point sequence prueba aqui prueba es un tipo secuencia de Arcos

                }
                else if (IsNext(TokenType.LEFT_PARENTHESIS))
                {
                    Eat(TokenType.LEFT_PARENTHESIS);
                    HayBracket = true;
                    List<Node> PuntosParaCrearArco = new List<Node>();
                    Node ExpresionesParaArcos = BuildExpression(actualScope);
                    PuntosParaCrearArco.Add(ExpresionesParaArcos);
                    while (actual_token.Type == TokenType.Comma)
                    {
                        Eat(TokenType.Comma);
                        ExpresionesParaArcos = BuildExpression(actualScope);
                        PuntosParaCrearArco.Add(ExpresionesParaArcos);
                    }
                    Eat(TokenType.RIGHT_PARENTHESIS);
                    HayBracket = false;
                    if (PuntosParaCrearArco.Count != 4) new Error(ErrorKind.Semantic,"arc function must recieve 4 parameters",actualLine);
                    result = new Arco(PuntosParaCrearArco[0], PuntosParaCrearArco[1], PuntosParaCrearArco[2], PuntosParaCrearArco[3], actualLine);


                }
                else
                {
                    //TIene que ser un identificador arc p1;
                    string name = actual_token.Value.ToString();
                    actualLine = actual_token.actualLine;
                    Eat(TokenType.Identifier, "Se esperaba un identificador despues de la declaracion de arco");
                    actualScope.AddCOnstant(name, new Arco(actualLine));
                    IsDeclaration = true;

                }
                return (result, IsDeclaration);

            }
            public (Node, bool) InstanciaCircunferencia(Scope actualScope)
            {

                Node result = null;
                int actualLine = actual_token.actualLine;
                bool IsDeclaration = false;
                Eat(TokenType.Keyword, "");
                if (IsNext(TokenType.SequenceKeyword))
                {//Es point sequence prueba aqui prueba es un tipo secuencia de Arcos

                }
                else if (IsNext(TokenType.LEFT_PARENTHESIS))
                {
                    Eat(TokenType.LEFT_PARENTHESIS, "");
                    HayBracket = true;
                    List<Node> PuntosParaCrearCircle = new List<Node>();
                    Node ValuePuntosParaCrearCircles = BuildExpression(actualScope);
                    PuntosParaCrearCircle.Add(ValuePuntosParaCrearCircles);
                    while (actual_token.Type == TokenType.Comma)
                    {
                        Eat(TokenType.Comma, "");
                        ValuePuntosParaCrearCircles = BuildExpression(actualScope);
                        PuntosParaCrearCircle.Add(ValuePuntosParaCrearCircles);
                    }
                    Eat(TokenType.RIGHT_PARENTHESIS, "");
                    HayBracket = false;
                    if (PuntosParaCrearCircle.Count != 2) new Error(ErrorKind.Semantic,"circle function must recieve two parameters",actualLine);
                    result = new Circunferencia(PuntosParaCrearCircle[0], PuntosParaCrearCircle[1], actualLine);
                }
                else
                {
                    //TIene que ser un identificador circle p1;
                    string name = actual_token.Value.ToString();
                    actualLine = actual_token.actualLine;
                    Eat(TokenType.Identifier, "Se esperaba un identificador despues de la declaracion de circle");
                    actualScope.AddCOnstant(name, new Circunferencia(actualLine));
                    IsDeclaration = true;
                }
                return (result, IsDeclaration);

            }
            public Node Print(Scope actualScope)
            {
                int actualLine = actual_token.actualLine;
                Eat(TokenType.Keyword, "");
                Node result = new Print(BuildExpression(actualScope), actualLine);
                return result;

            }

        }
    }
}
