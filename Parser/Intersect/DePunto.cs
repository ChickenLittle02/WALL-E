namespace BackEnd;
public static partial class Intersection
{
    public static Sequence Intersect(Punto punto1, Punto punto2, int actualLine)
    {
        List<Node> Puntos = new List<Node>();

        if (punto1.X == punto2.X && punto1.Y == punto2.Y)
        {
            Puntos.Add(punto1);
        }
        FiniteSequence result = new FiniteSequence(Puntos, false, actualLine);
        result.Start();
        return result;

    }

public static Sequence Intersect(Line recta1, Punto punto1,  int actualLine)
    {
        return Intersect( punto1, recta1, actualLine);
    
    }
    public static Sequence Intersect(Punto punto1, Line recta1, int actualLine)
    {
        Punto rectaP1, rectaP2;
        Punto.TryParse(recta1.Punto1.Value, out rectaP1);
        Punto.TryParse(recta1.Punto2.Value, out rectaP2);
        rectaP1.Start(); rectaP2.Start();
        List<Node> Puntos = new List<Node>();
        var (m, n) = LineEquation(recta1);

        if (rectaP1.X == rectaP2.X && punto1.X == rectaP1.X || punto1.Y == (m * punto1.X) + n)
        { // posibles casos en los que el punto pertenece a la recta.
            Puntos.Add(punto1);
        }
        
        FiniteSequence result = new FiniteSequence(Puntos, false, actualLine);
        result.Start();
        return result;

    }
    
    public static Sequence Intersect(Segment segmento1, Punto punto1, int actualLine)
    {
        return Intersect(punto1,segmento1, actualLine);
    }

    public static Sequence Intersect(Punto punto1, Segment segmento1, int actualLine)
    {
        List<Node> Puntos = new List<Node>();

        if (IsInSegment(punto1, segmento1))
        {
            //aqui hay que retornar una secuencia con el punto p1 
            Puntos.Add(punto1);
        }
        FiniteSequence result = new FiniteSequence(Puntos, false, actualLine);
        result.Start();
        return result;

    }
    public static Sequence Intersect(Ray ray, Punto punto1, int actualLine)
    {
        return Intersect(punto1, ray,  actualLine);
    }

    public static Sequence Intersect(Punto punto1, Ray ray, int actualLine)
    {
        List<Node> punto = new List<Node>();
        if (IsInRay(punto1, ray))
        {
            punto.Add(punto1);
        }
        var result = new FiniteSequence(punto, false, actualLine);
        result.Start();
        return result;
    }
    
    public static Sequence Intersect(Arco arco, Punto punto1, int actualLine)
    { 
        return Intersect( punto1, arco, actualLine);
    }

    public static Sequence Intersect(Punto punto1, Arco arco, int actualLine)
    { 
         List<Node> punto = new List<Node>();
        if (IsInArc(punto1, arco))
        {
            punto.Add(punto1);
        }

        var result = new FiniteSequence(punto, false, actualLine);
        result.Start();
        return result;
    }
    
    public static Sequence Intersect(Circunferencia circunferencia, Punto point, int actualLine)
    {
        return Intersect(point, circunferencia, actualLine);
    }
    public static Sequence Intersect(Punto point, Circunferencia circunferencia, int actualLine)
    {
        List<Node> Puntos = new List<Node>();
        Punto circunferenciaCentro;
        if(!Punto.TryParse(circunferencia.Centro.Value, out circunferenciaCentro)) new Error(ErrorKind.RunTime,"Unexpected error: There will be a Point in Intersect function",actualLine);
        circunferenciaCentro.Start();
        double Equation = Math.Pow(circunferenciaCentro.X - point.X, 2) + Math.Pow(circunferenciaCentro.Y - point.Y, 2);
        if (Equation == Math.Pow(circunferencia.radio, 2))
        {
            Puntos.Add(point);
        }

        var result = new FiniteSequence(Puntos, false, actualLine);
        result.Start();
        return result;
    }


}
