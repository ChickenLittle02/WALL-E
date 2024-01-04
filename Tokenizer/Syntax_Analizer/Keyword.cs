using System.Xml.XPath;

namespace Syntax_Analizer
{
    partial class Syntax
    {
        public Node Print(Scope actualScope)
        {
            int actualLine = actual_token.actualLine;
            Eat(TokenType.Keyword,"");
            Node result = new Print(BuildExpression(actualScope),actualLine);
            return result;

        }
        public Node InstanciaCircunferencia(Scope actualScope)
        { Node result = null;
            Eat(TokenType.Keyword,"");
            if(IsNext(TokenType.SequenceKeyword))
            {//Es point sequence prueba aqui prueba es un tipo secuencia de puntos

            }else{
                //TIene que ser un identificador point p1;
                string name = actual_token.Value.ToString();
                int actualLine = actual_token.actualLine;
                Eat(TokenType.Identifier,"Se esperaba un identificador");
                actualScope.AddCOnstant(name,new Punto(actualLine));                
            }
            return result;

        }
        public Node InstanciaLinea(Scope actualScope)
        { Node result = null;
            int LineaInstanciadeLinea = actual_token.actualLine; 
            Eat(TokenType.Keyword,"");
            if(IsNext(TokenType.SequenceKeyword))
            {//Es point sequence prueba aqui prueba es un tipo secuencia de puntos

            }else if(IsNext(TokenType.LEFT_PARENTHESIS)){
                //TIene que ser un identificador line p1;
                string name = actual_token.Value.ToString();
                int actualLine = actual_token.actualLine;
                List<Node> PuntosParaCrearLinea = new List<Node>();
                PuntosParaCrearLinea.Add(new Constants(name,actualScope,actualLine));
                Eat(TokenType.Identifier,"Se esperaba un identificador");
                while(actual_token.Type == TokenType.Comma)
                {
                    actualLine = actual_token.actualLine;
                    name = actual_token.Value.ToString();
                    Eat(TokenType.Identifier,"Se esperaba un identificador");
                PuntosParaCrearLinea.Add(new Constants(name,actualScope,actualLine));

                }
                if(PuntosParaCrearLinea.Count!=2) throw new Exception("Se necesitan dos puntos para crear una linea");
                result = new SystemFunction(new Line(PuntosParaCrearLinea[0],PuntosParaCrearLinea[1],actualLine),LineaInstanciadeLinea);
            }
            return result;

        }
        public Node InstanciaPunto(Scope actualScope)
        { Node result = null;
            Eat(TokenType.Keyword,"");
            if(IsNext(TokenType.SequenceKeyword))
            {//Es point sequence prueba aqui prueba es un tipo secuencia de puntos

            }else{
                //TIene que ser un identificador point p1;
                string name = actual_token.Value.ToString();
                int actualLine = actual_token.actualLine;
                Eat(TokenType.Identifier,"Se esperaba un identificador");
                actualScope.AddCOnstant(name,new Punto(actualLine));
                
            }
            return result;

        }
    }
}