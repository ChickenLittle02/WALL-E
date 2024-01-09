namespace BackEnd;
public partial class Intersection
{
    public static Sequence Intersect(Line recta1, Line recta2, int actualLine)
    {//este metodo es para obtener la secuencia resultado de intersectar dos rectas

        List<Node> Puntos = new List<Node>();

        var (m1, n1) = LineEquation(recta1);
        var (m2, n2) = LineEquation(recta2);

        if (m1 == m2)
        {
            //las rectas son paralelas si las pendientes son iguales 
            //aqui tiene que retornar una secuencia vacia
            var resultado = new FiniteSequence(Puntos, false, actualLine);
            resultado.Start();
            return resultado;

        }
        else if (m1 == m2 && n1 == n2)
        {
            //si las pendientes son iguales y los intercectos con el eje y tambien entonces las rectas son iguales 
            //aqui tiene que retornar undefined 
            var resultado = new UndefinedSequence(actualLine);
            resultado.Start();
            return resultado;
        }
        //si no pasa algo de esto entonces se calculan los intersectos 
        Punto recta1Punto1, recta1Punto2, recta2Punto1, recta2Punto2;
        Punto.TryParse(recta1.Punto1.Value, out recta1Punto1); recta1Punto1.Start();
        Punto.TryParse(recta1.Punto2.Value, out recta1Punto2); recta1Punto2.Start();
        Punto.TryParse(recta2.Punto1.Value, out recta2Punto1); recta2Punto1.Start();
        Punto.TryParse(recta2.Punto2.Value, out recta2Punto2); recta2Punto2.Start();

        double x1 = recta1Punto1.X;
        double y1 = recta1Punto1.Y;
        double x2 = recta1Punto2.X;
        double y2 = recta1Punto2.Y;

        double x3 = recta2Punto1.X;
        double y3 = recta2Punto1.Y;
        double x4 = recta2Punto2.X;
        double y4 = recta2Punto2.Y;

        double denominador = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

        double x = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denominador;
        double y = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denominador;

        //aqui deberia retornar una secuencia con los Puntos de la interseccion
        Puntos.Add(new Punto(x, y, actualLine));
        var result = new FiniteSequence(Puntos, false, actualLine);
        result.Start();
        return result;

    }
    public static Sequence Intersect(Circunferencia circunferencia, Line recta, int actualLine)
    {
        return Intersect(recta, circunferencia, actualLine);
    }

    public static Sequence Intersect(Line recta, Circunferencia circunferencia, int actualLine)
    {
        // este metodo es para intersectar una circunferencia y una recta 
        var (m, n) = LineEquation(recta);
        Punto recta1Punto1, recta1Punto2, centro;
        Punto.TryParse(recta.Punto1.Value, out recta1Punto1); recta1Punto1.Start();
        Punto.TryParse(recta.Punto2.Value, out recta1Punto2); recta1Punto2.Start();

        Punto.TryParse(circunferencia.Centro, out centro); centro.Start();
        var radius = circunferencia.radio;

        double centroX = centro.X;
        double centroY = centro.Y;

        //Ecuacion de Discriminante : b^2 -4*a*c.
        double A = 1 + Math.Pow(m, 2);
        double B = 2 * (m * n - m * centroY - centroX);
        double C = Math.Pow(centroY, 2) - Math.Pow(radius, 2) + Math.Pow(centroX, 2) - 2 * n * centroY + Math.Pow(n, 2);

        double discriminant = Math.Pow(B, 2) - 4 * A * C;//calculo del discriminante 

        // Distancia del centro a la recta
        double distance = PointLineDistance(centro, recta);

        List<Node> intersections = new List<Node>();
        if (distance > radius)
        {
            var resultado = new FiniteSequence(intersections, false, actualLine);
            resultado.Start();
            return resultado;
        }

        if (recta1Punto1.X == recta1Punto2.X) // Si la línea es vertical (pendiente indefinida)
        {
            double lineX = recta1Punto1.X; // Obtenemos el valor de x de la línea (x = c)
            discriminant = Math.Pow(radius, 2) - Math.Pow((lineX - centroX), 2);

            if (discriminant == 0) // Un solo punto de intersección
            {
                double y = centroY + Math.Sqrt(discriminant);
                intersections.Add(new Punto(lineX, y, actualLine));
            }
            else if (discriminant > 0) // Dos puntos de intersección
            {
                double y1 = centroY + Math.Sqrt(discriminant);
                double y2 = centroY - Math.Sqrt(discriminant);

                intersections.Add(new Punto(lineX, y1, actualLine));
                intersections.Add(new Punto(lineX, y2, actualLine));
            }
        }
        else if (distance == radius)
        {
            double x = (-B) / (2 * A);
            double y = m * x + n;
            intersections.Add(new Punto(x, y, actualLine));
        }
        else if (discriminant >= 0)
        {
            double x1 = (-B + Math.Sqrt(discriminant)) / (2 * A);
            double x2 = (-B - Math.Sqrt(discriminant)) / (2 * A);

            double y1 = m * x1 + n;
            double y2 = m * x2 + n;

            intersections.Add(new Punto(x1, y1, actualLine));
            intersections.Add(new Punto(x2, y2, actualLine));
        }
        var result = new FiniteSequence(intersections, false, actualLine);
        result.Start();
        return result;
    }
    public static Sequence Intersect(Segment segmento, Line recta, int actualLine)
    {
        return Intersect(recta, segmento, actualLine);
    }

    public static Sequence Intersect(Line recta, Segment segmento, int actualLine)
    {
        Line recta2 = new(segmento.Punto1, segmento.Punto2, actualLine);

        Sequence possibleIntersections = Intersect(recta, recta2, actualLine);

        if (possibleIntersections is not UndefinedSequence)
        {
            FiniteSequence seq = (FiniteSequence)possibleIntersections;

            List<Node> intersections = new List<Node>();

            foreach (var point in intersections)
            {
                if (IsInSegment((Punto)point, segmento))
                {
                    intersections.Add(point);
                }
            }
            var resultado =  new FiniteSequence(intersections, false, actualLine);
            resultado.Start();
            return resultado;
        }
        // Este es el caso en que la recta y el segmento esten superpuestos
        var result = new UndefinedSequence(actualLine);
        result.Start();
        return result;
    }

    public static Sequence Intersect(Ray ray, Line recta, int actualLine)
    {
        return Intersect(recta, ray, actualLine);
    }

    public static Sequence Intersect(Line recta, Ray ray, int actualLine)
    {
        Line newLine = new(ray.Punto1, ray.Punto2, actualLine);
        object possibleIntersections = Intersect(recta, newLine, actualLine);

        if (possibleIntersections is not UndefinedSequence)
        {
            FiniteSequence seq = (FiniteSequence)possibleIntersections;
            List<Node> intersections = seq.GetELements;
            List<Node> validintersections = new List<Node>();
            foreach (Punto point in intersections.ToList())
            {
                if (IsInRay(point, ray))
                {
                    validintersections.Add(point);
                }
            }
            var result = new FiniteSequence(validintersections, false, actualLine);
            result.Start();
            return result;
        }
        // Line and ray overlap
        var resultado = new  UndefinedSequence(actualLine);
        resultado.Start();
        return resultado;

    }
    public static Sequence Intersect(Arco arc, Line recta, int actualLine)
    {
        return Intersect(recta, arc, actualLine);
    }

    public static Sequence Intersect(Line recta, Arco arc, int actualLine)
    {
        Circunferencia circle = new(arc.Centro, arc.Radio, actualLine);
        object possibleIntersections = Intersect(recta, circle, actualLine);
        if (possibleIntersections is not UndefinedSequence)
        {
            FiniteSequence seq = (FiniteSequence)possibleIntersections;
            List<Node> intersections = seq.GetELements;
            List<Node> validintersections = new List<Node>();
            foreach (Punto point in intersections)
            {
                if (IsInArc(point, arc))
                {
                    validintersections.Add(point);
                }
            }
            var result = new FiniteSequence(validintersections, false, actualLine);
            result.Start();
            return result;
        }
        var resultado = new FiniteSequence(new List<Node>(), false, actualLine);
        resultado.Start();
        return resultado;
    }

}


