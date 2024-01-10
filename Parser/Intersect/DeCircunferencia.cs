namespace BackEnd;
public static partial class Intersection
{
    // las intersecciones entre "Cirunferencia y Punto, Linea, segmento y  rayo" se encuentran en los archivos "DePunto, "DeLinea", "DeSegmento" y "DeRayo" respectivamente. 

    public static Sequence Intersect(Circunferencia circunferencia1, Circunferencia circunferencia2, int actualLine)
    {
        List<Node> intersections = new List<Node>();
        Punto circunferencia1Centro, circunferencia2Centro;
        if(!Punto.TryParse(circunferencia1.Centro.Value, out circunferencia1Centro)) new Error(ErrorKind.RunTime,"Unexpected error: There will be a Point in Intersect function",actualLine); 
        circunferencia1Centro.Start();
        if(!Punto.TryParse(circunferencia2.Centro.Value, out circunferencia2Centro)) new Error(ErrorKind.RunTime,"Unexpected error: There will be a Point in Intersect function",actualLine); 
        circunferencia2Centro.Start();

        double x1 = circunferencia1Centro.X;
        double y1 = circunferencia1Centro.Y;
        double r1 = circunferencia1.radio;

        double x2 = circunferencia2Centro.X;
        double y2 = circunferencia2Centro.Y;
        double r2 = circunferencia1.radio;

        double distancia = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

        if (x1 == x2 && y1 == y2 && r1 == r2)
        {
            UndefinedSequence resultado = new UndefinedSequence(actualLine);
            resultado.Start();
            return resultado;
        }
        else if (distancia > r1 + r2 || distancia < Math.Abs(r1 - r2) || distancia == 0)
        {
            var resultado = new FiniteSequence(new List<Node>(), false, actualLine); // las circunferencias no se intersectan en ningun punto
            resultado.Start();
            return resultado;
        }

        else if (distancia == r1 + r2 || distancia == Math.Abs(r1 - r2))
        {
            // Las circunferencias targentes solo se intersecan en un punto
            double x = (r1 * x2 + r2 * x1) / (r1 + r2);
            double y = (r1 * y2 + r2 * y1) / (r1 + r2);
            intersections.Add(new Punto(x, y, actualLine));
        }
        else
        {
            // Las circunferencias se intersecan en dos puntos 
            double a = (Math.Pow(r1, 2) - Math.Pow(r2, 2) + Math.Pow(distancia, 2)) / (2 * distancia);
            double h = Math.Sqrt(Math.Pow(r1, 2) - Math.Pow(a, 2));

            double x = x1 + (a * (x2 - x1)) / distancia;
            double y = y1 + (a * (y2 - y1)) / distancia;

            double intersectX1 = x + (h * (y2 - y1)) / distancia;
            double intersectY1 = y - (h * (x2 - x1)) / distancia;

            double intersectX2 = x - (h * (y2 - y1)) / distancia;
            double intersectY2 = y + (h * (x2 - x1)) / distancia;

            intersections.Add(new Punto(intersectX1, intersectY1, actualLine));
            intersections.Add(new Punto(intersectX2, intersectY2, actualLine));
        }
        var result = new FiniteSequence(intersections, false, actualLine);
        result.Start();
        return result;
    }
    public static Sequence Intersect(Circunferencia circle, Arco arc, int actualLine)
    {
        return Intersect(arc, circle, actualLine);
    }


    public static Sequence Intersect(Arco arc, Circunferencia circle, int actualLine)
    {
        Circunferencia c = new(arc.Centro, arc.Radio, actualLine);
        object possibleIntersections = Intersect(circle, c, actualLine);

        // Circle and arc do not overlap
        if (possibleIntersections is FiniteSequence)
        {
            FiniteSequence seq = (FiniteSequence)possibleIntersections;
            List<Node> intersections = seq.GetELements;
            List<Node> validintersections = new List<Node>();
            // Remove intersections that are not in the arc
            foreach (Punto point in intersections)
            {
                if (IsInArc(point, arc))
                {
                    validintersections.Add(point);
                }
            }
            var resultado = new FiniteSequence(validintersections, false, actualLine);
            resultado.Start();
            return resultado;
        }
        // Circle and arc overlap
        var result = new UndefinedSequence(actualLine);
        result.Start();
        return result;
    }


}
