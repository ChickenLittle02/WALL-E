namespace BackEnd;
public partial class Intersection
{
    // interseccion entre Segmento y Punto hecho en el archivo "DePunto.cs"

    // interseccion entre Segmento y Linea hecho en el archivo "DeLinea.cs"

    public static Sequence Intersect(Segment segment1, Segment segment2, int actualLine)
    {
        Line line1 = new(segment1.Punto1, segment1.Punto2, actualLine);
        Line line2 = new(segment2.Punto1, segment2.Punto2, actualLine);
        object possibleIntersections = Intersect(line1, line2, actualLine);
        if (possibleIntersections is FiniteSequence)
        {
            FiniteSequence seq = (FiniteSequence)possibleIntersections;
            List<Node> intersections = seq.GetELements;
            List<Node> validintersections = new List<Node>();
            foreach (Punto point in intersections.ToList())
            {
                if (IsInSegment(point, segment1) && IsInSegment(point, segment2))
                {
                    validintersections.Add(point);
                }
            }
            return new FiniteSequence(validintersections, false, actualLine);
        }
        // Segments overlap
        else return new UndefinedSequence(actualLine);
    }
    
    public static Sequence Intersect(Ray ray, Segment segment, int actualLine)
    { 
        return Intersect( segment, ray, actualLine);
    }

    public static Sequence Intersect(Segment segment, Ray ray, int actualLine)
    {
        Line line = new(ray.Punto1, ray.Punto2, actualLine);
        Sequence possibleIntersections = Intersect(line, segment, actualLine);
        if (possibleIntersections is not UndefinedSequence)
        {
            FiniteSequence seq = (FiniteSequence)possibleIntersections;
            List<Node> intersections = seq.GetELements;
            List<Node> validintersections = new List<Node>();
            foreach (Punto point in intersections)
            {
                if (IsInRay(point, ray))
                {
                    validintersections.Add(point);
                }
            }
            return new FiniteSequence(validintersections, false, actualLine);
        }
        else return new UndefinedSequence(actualLine);
    }
    public static Sequence Intersect(Circunferencia circunferencia, Segment segment, int actualLine)
    {
        return Intersect(segment, circunferencia, actualLine); 
    }

    public static Sequence Intersect(Segment segment, Circunferencia circunferencia, int actualLine)
    {
        Line line = new(segment.Punto1, segment.Punto2, actualLine);
        Sequence possibleIntersections = Intersect(line, circunferencia, actualLine);
        if (possibleIntersections.GetELements.Count != 0)
        {
            FiniteSequence seq = (FiniteSequence)possibleIntersections;
            List<Node> intersections = seq.GetELements;
            List<Node> validintersections = new List<Node>();
            foreach (Punto point in intersections.ToList())
            {
                if (IsInSegment(point, segment))
                {
                    validintersections.Add(point);
                }
            }
            return new FiniteSequence(validintersections, false, actualLine);
        }
        else return possibleIntersections;
    }
    public static Sequence Intersect(Arco arc,Segment segment,  int actualLine)
    {
        return Intersect(segment, arc, actualLine);
    }
    
    public static Sequence Intersect(Segment segment, Arco arc, int actualLine)
    {
        Circunferencia circle = new (arc.Centro, arc.Radio, actualLine);
        Sequence possibleIntersections = Intersect(segment, circle, actualLine);
        if (possibleIntersections.GetELements.Count!=0)
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
            return new FiniteSequence(validintersections,false, actualLine);
        }
        else return new FiniteSequence(new List<Node>(), false, actualLine);
    }
}