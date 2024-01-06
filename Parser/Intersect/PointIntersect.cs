
    // public static partial class Intersect
    // {
    //     public static Node PointIntersect(Punto punto1, Punto punto2, int actualLine)
    //     {
    //         Node result = null!;
    //         List<Node> Puntos = new List<Node>();

    //         if (punto1.X == punto2.X && punto1.Y == punto2.Y)
    //         {
    //             Puntos.Add(punto1);
    //             result = new FiniteSequence(Puntos, false, actualLine);
    //             return result;
    //         }
    //         else
    //         {
    //             return new FiniteSequence(Puntos, false, actualLine);
    //         }
    //     }

    //     public static Node PointLineIntersect(Punto punto1, Line recta1, int actualLine)
    //     {
    //         Node result = null!;
    //         List<Node> Puntos = new List<Node>();

    //         var (m, n) = LineEquation(recta1);

    //         if (punto1.Y == (m * punto1.X) + n)
    //         {
    //             //este es el caso en que el punto pertenece a la recta 
    //             Puntos.Add(punto1);
    //             result = new FiniteSequence(Puntos, false, actualLine);
    //             return result;
    //         }
    //         else
    //         {
    //             return  new FiniteSequence(Puntos, false, actualLine);
    //         }
    //     }
    //     public static Node PointSegmentIntersect(Punto punto1, Segmento segmento1, int actualLine)
    //     {
    //         Node result = null!;
    //         List<Node> Puntos = new List<Node>();
    //         if (IsInSegment(punto1, segmento1))
    //         {
    //             //aqui hay que retornar una secuencia con el punto p1 
    //             Puntos.Add(punto1);
    //             result = new FiniteSequence(Puntos, false, actualLine);
    //             return result;

    //         }
    //         else
    //         {
    //             //en este caso hay que retornar una secuencia vacia
    //             return  new FiniteSequence(Puntos, false, actualLine);
    //         }
    //     }

    //     public static Node PointCircleIntersect(Punto punto, Circunferencia circunferencia,int actualLine)
    //     {
    //         Node result = null!;
    //         List<Node> Puntos = new List<Node>();

    //         double miembroDerechoDeLaEcuacion = Math.Pow(punto.X - circunferencia.Centro.X,2) + Math.Pow(punto.Y - circunferencia.Centro.Y,2);
    //         if (miembroDerechoDeLaEcuacion == Math.Pow(circunferencia.Radio , 2)){

    //             Puntos.Add(punto);
    //             result = new FiniteSequence(Puntos,false , actualLine);
    //             return result;
    //         }
    //         return new FiniteSequence(Puntos,false,actualLine);
    //     }
    // }
