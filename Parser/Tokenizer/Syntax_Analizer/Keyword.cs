namespace BackEnd
{

    namespace Syntax_Analizer
    {
        public partial class Syntax
        {
            public Node WorkWithKeywords(Scope actualScope)
            {
                string name = actual_token.Value.ToString();
                Node result = null;
                if (name == "Print")    result = Print(actualScope);
                else if (name == "point")   result = InstanciaPunto(actualScope);
                else if(name =="line") result = InstanciaLinea(actualScope);
                else if (name == "circle")  result = InstanciaCircunferencia(actualScope);
                return result;

            }
            public Node InstanciaPunto(Scope actualScope)
            {
                Node result = null;
                int actualLine = actual_token.actualLine;
                Eat(TokenType.Keyword, "");
                if (IsNext(TokenType.SequenceKeyword))
                {//Es point sequence prueba aqui prueba es un tipo secuencia de puntos

                }
                else if (IsNext(TokenType.LEFT_PARENTHESIS))
                {
                    //Significa que es la funcion punto point(1,2);
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
                    if (PointExpression.Count != 2) throw new Exception("La funcion punto recibe solo dos parametros");
                    result = new PointFunction(PointExpression[0], PointExpression[1], actualLine);
                }
                else
                {
                    //Tiene que ser un identificador point p1;
                    string name = actual_token.Value.ToString();
                    Eat(TokenType.Identifier, "Se esperaba un identificador");
                    actualScope.AddCOnstant(name, new Punto(actualLine));
                }
                return result;

            }
            public Node InstanciaLinea(Scope actualScope)
            {
                Node result = null;
                    int actualLine = actual_token.actualLine;
                Eat(TokenType.Keyword, "");
                if (IsNext(TokenType.SequenceKeyword))
                {//Es point sequence prueba aqui prueba es un tipo secuencia de puntos

                }
                else if (IsNext(TokenType.LEFT_PARENTHESIS))
                {
                    List<Node> PuntosParaCrearLinea = new List<Node>();
                    Node ExpresionesParaLineas = BuildExpression(actualScope);
                    PuntosParaCrearLinea.Add(ExpresionesParaLineas);
                    while (actual_token.Type == TokenType.Comma)
                    {
                        ExpresionesParaLineas = BuildExpression(actualScope);
                        PuntosParaCrearLinea.Add(ExpresionesParaLineas);
                    }
                    if (PuntosParaCrearLinea.Count != 2) throw new Exception("La funcion line recibe dos puntos de parametros");
                    result = new SystemFunction(new Line(PuntosParaCrearLinea[0], PuntosParaCrearLinea[1], actualLine), actualLine);

                }else{
                    //TIene que ser un identificador line p1;
                    
                    string name = actual_token.Value.ToString();
                    actualLine = actual_token.actualLine;
                    Eat(TokenType.Identifier,"Se esperaba un identificador despues de la declaracion de line");
                    actualScope.AddCOnstant(name, new Line(actualLine));

                }
                return result;

            }
            public Node InstanciaCircunferencia(Scope actualScope)
            {
                Node result = null;
                Eat(TokenType.Keyword, "");
                if (IsNext(TokenType.SequenceKeyword))
                {//Es point sequence prueba aqui prueba es un tipo secuencia de puntos

                }
                else
                {
                    //TIene que ser un identificador point p1;
                    string name = actual_token.Value.ToString();
                    int actualLine = actual_token.actualLine;
                    Eat(TokenType.Identifier, "Se esperaba un identificador");
                    actualScope.AddCOnstant(name, new Punto(actualLine));
                }
                return result;

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
