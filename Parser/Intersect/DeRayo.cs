namespace BackEnd;
public partial class Intersection
{
    // interseccion entre rayo y punto esta hecho en el archivo "DePunto.cs"

    // interseccion entre rayo y recta esta hecho en el archvo "DeLinea.cs"

    // interseccion entre rayo y segmento esta hecho en el archivo "DeSegmento.cs"

    public static Sequence Intersect(Ray ray1, Ray ray2, int actualLine)
    {
        Line line1 = new(ray1.Punto1, ray1.Punto2, actualLine);
        Line line2 = new(ray2.Punto1, ray2.Punto2, actualLine);
        Sequence possibleIntersections = Intersect(line1, line2, actualLine);
        if (possibleIntersections is not UndefinedSequence)
        {
            FiniteSequence seq = (FiniteSequence)possibleIntersections;
            List<Node> intersections = seq.GetELements;
            List<Node> validintersections = new List<Node>();
            foreach (Punto point in intersections.ToList())
            {
                if (IsInRay(point, ray1) && IsInRay(point, ray2))
                {
                    validintersections.Add(point);
                }
            }
            return new FiniteSequence(validintersections, false, actualLine);
        }
        // Rays overlap
        else return possibleIntersections;
    }
    public static Sequence Intersect(Circunferencia circle, Ray ray, int actualLine)
    {
        return Intersect(ray, circle, actualLine);
    }

    public static Sequence Intersect(Ray ray, Circunferencia circle, int actualLine)
    {
        Line line = new(ray.Punto1, ray.Punto2, actualLine);
        Sequence possibleIntersections = Intersect(line, circle, actualLine);
        if (possibleIntersections.GetELements.Count != 0)
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
            return new FiniteSequence(validintersections, false, actualLine);
        }
        else return possibleIntersections;
    }
    public static Sequence Intersect(Arco arco, Ray rayo, int actualLine)
    {
        return Intersect(rayo, arco, actualLine);

    }
    public static Sequence Intersect(Ray rayo, Arco arco, int actualLine)
    {
        Line line = new(rayo.Punto1, rayo.Punto2, actualLine);
        Sequence possibleIntersections = Intersect(line, arco, actualLine);
        if (possibleIntersections.GetELements.Count != 0)
        {
            FiniteSequence seq = (FiniteSequence)possibleIntersections;
            List<Node> intersections = seq.GetELements;
            List<Node> validintersections = new List<Node>();
            foreach (Punto point in intersections)
            {
                if (IsInRay(point, rayo))
                {
                    validintersections.Add(point);
                }
            }
            return new FiniteSequence(validintersections, false, actualLine);
        }
        else return possibleIntersections;
    }
}