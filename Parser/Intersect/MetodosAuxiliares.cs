using System.Numerics;
using System.Runtime.InteropServices;

namespace BackEnd;

public static partial class Intersection
{
    public static bool IsInSegment(Punto punto, Segment segmento)
    {
        Punto segmentoPunto1, segmentoPunto2;
        Punto.TryParse(segmento.Punto1, out segmentoPunto1);
        Punto.TryParse(segmento.Punto2, out segmentoPunto2);
        double minX = Math.Min(segmentoPunto1.X, segmentoPunto2.X);
        double maxX = Math.Max(segmentoPunto1.X, segmentoPunto2.X);
        double minY = Math.Min(segmentoPunto1.Y, segmentoPunto2.Y);
        double maxY = Math.Max(segmentoPunto1.Y, segmentoPunto2.Y);

        // Comprueba si los puntos estan dentro de de cuadro delimitador del segmento
        if (punto.X >= minX && punto.X <= maxX && punto.Y >= minY && punto.Y <= maxY)
        {
            // Ecuacion Parametrica de un segmento
            double t = ((punto.X - segmentoPunto1.X) * (segmentoPunto2.X - segmentoPunto1.X) +
                        (punto.Y - segmentoPunto1.Y) * (segmentoPunto2.Y - segmentoPunto1.Y)) /
                        (Math.Pow(segmentoPunto2.X - segmentoPunto1.X, 2) + Math.Pow(segmentoPunto2.Y - segmentoPunto1.Y, 2));

            // revisar si el punto esta contenido en el segmento
            if (t >= 0 && t <= 1)
            {
                return true;
            }
        }
        return false;
    }
    public static (double, double) LineEquation(Line recta)
    {
        Punto rectaPunto1, rectaPunto2;
        Punto.TryParse(recta.Punto1, out rectaPunto1);
        Punto.TryParse(recta.Punto2, out rectaPunto2);
        //para hallar la ecuacion de una recta se necesita la pendiente y un ounto de la recta para hallar el intercepto con el eje y
        double x1 = rectaPunto1.X;
        double x2 = rectaPunto2.X;
        double y1 = rectaPunto1.Y;
        double y2 = rectaPunto2.Y;


        //hallar la pendiente
        double m = (y2 - y1) / (x2 - x1);

        //intersecto con el eje y 
        double n = y1 - (m * x1);

        return (m, n);

    }
    public static double PointLineDistance(Punto punto, Line recta)
    {
        Punto rectaPunto1, rectaPunto2;
        Punto.TryParse(recta.Punto1, out rectaPunto1);
        Punto.TryParse(recta.Punto2, out rectaPunto2);
        double x1 = rectaPunto1.X;
        double y1 = rectaPunto1.Y;
        double x2 = rectaPunto2.X;
        double y2 = rectaPunto2.X;
        double x0 = punto.X;
        double y0 = punto.Y;

        return Math.Abs((y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1) / Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
    }

    public static bool IsInRay(Punto point, Ray ray)
    {
        Segment segment = new Segment(ray.Punto1, ray.Punto2, ray.ActualLine);
        Punto rayP1, rayP2;
        Punto.TryParse(ray.Punto1, out rayP1);
        Punto.TryParse(ray.Punto2, out rayP2);
        return IsInSegment(point, segment) || (PointDistance(point, rayP2) <= PointDistance(point, rayP1));
    }
    public static double PointDistance(Punto point1, Punto point2)
    {
        return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
    }
    public static bool IsInArc(Punto point, Arco arc)
    {
        Punto arcPunto1, arcPunto2, arcCentro;
        Punto.TryParse(arc.Punto1, out arcPunto1);
        Punto.TryParse(arc.Punto2, out arcPunto2);
        Punto.TryParse(arc.Centro, out arcCentro);
        Vector2 centerToPoint = new Vector2((float)(point.X - arcCentro.X), (float)(point.Y - arcCentro.Y));
        Vector2 initialRay = new Vector2((float)(arcPunto1.X - arcCentro.X), (float)(arcPunto1.Y - arcCentro.Y));
        Vector2 finalRay = new Vector2((float)(arcPunto2.X - arcCentro.X), (float)(arcPunto2.Y - arcCentro.Y));

        float angleToPoint = MathF.Atan2(centerToPoint.Y, centerToPoint.X);
        float angleToInitialRay = MathF.Atan2(initialRay.Y, initialRay.X);
        float angleToFinalRay = MathF.Atan2(finalRay.Y, finalRay.X);

        // Adjust angles to be between 0 and 2*PI
        if (angleToInitialRay < 0)
        {
            angleToInitialRay += 2 * MathF.PI;
        }
        if (angleToFinalRay < 0)
        {
            angleToFinalRay += 2 * MathF.PI;
        }
        if (angleToPoint < 0)
        {
            angleToPoint += 2 * MathF.PI;
        }

        // Verify if the point is between the initial and final rays
        if (angleToInitialRay < angleToFinalRay)
        {
            return angleToInitialRay <= angleToPoint && angleToPoint <= angleToFinalRay;
        }
        else
        {
            return angleToInitialRay <= angleToPoint || angleToPoint <= angleToFinalRay;
        }
    }

    public static Sequence IntersectionFigure(Node Figura1, Node Figura2, int ActualLine)
    {
        Figura Figura1Value = (Figura)Figura1;
        
        Figura Figura2Value = (Figura)Figura2;
        Sequence Resultado = null;
        if (Figura1Value is Punto)
        {
            if (Figura2Value is Punto) 
            Resultado = Intersection.Intersect((Punto)Figura1Value,(Punto)Figura2Value,ActualLine);

            else if (Figura2Value is Ray)
            Resultado = Intersection.Intersect((Punto)Figura1Value,(Ray)Figura2Value,ActualLine);

            else if (Figura2Value is Segment)
            Resultado = Intersection.Intersect((Punto)Figura1Value,(Segment)Figura2Value,ActualLine);

            else if (Figura2Value is Line)
            Resultado = Intersection.Intersect((Punto)Figura1Value,(Line)Figura2Value,ActualLine);

            else if (Figura2Value is Arco)
            Resultado = Intersection.Intersect((Punto)Figura1Value,(Arco)Figura2Value,ActualLine);
            
            else if (Figura2Value is Circunferencia)
            Resultado = Intersection.Intersect((Punto)Figura1Value,(Ray)Figura2Value,ActualLine);

        }
        else if (Figura1Value is Ray)
        {
            if (Figura2Value is Ray)
            Resultado = Intersection.Intersect((Ray)Figura1Value,(Ray)Figura2Value,ActualLine);

            else if (Figura2Value is Segment)
            Resultado = Intersection.Intersect((Ray)Figura1Value,(Segment)Figura2Value,ActualLine);

            else if (Figura2Value is Line)
            Resultado = Intersection.Intersect((Ray)Figura1Value,(Line)Figura2Value,ActualLine);

            else if (Figura2Value is Arco)
            Resultado = Intersection.Intersect((Ray)Figura1Value,(Arco)Figura2Value,ActualLine);
            
            else// (Figura2Value is Circunferencia)
            Resultado = Intersection.Intersect((Ray)Figura1Value,(Circunferencia)Figura2Value,ActualLine);

        }
        else if (Figura1Value is Segment)
        {
            if (Figura2Value is Ray)
            Resultado = Intersection.Intersect((Segment)Figura1Value,(Ray)Figura2Value,ActualLine);

            else if (Figura2Value is Segment)
            Resultado = Intersection.Intersect((Segment)Figura1Value,(Segment)Figura2Value,ActualLine);

            else if (Figura2Value is Line)
            Resultado = Intersection.Intersect((Segment)Figura1Value,(Line)Figura2Value,ActualLine);

            else if (Figura2Value is Arco)
            Resultado = Intersection.Intersect((Segment)Figura1Value,(Arco)Figura2Value,ActualLine);
            
            else// (Figura2Value is Circunferencia)
            Resultado = Intersection.Intersect((Segment)Figura1Value,(Circunferencia)Figura2Value,ActualLine);

        }
        else if (Figura1Value is Line)
        {
            if (Figura2Value is Ray)
            Resultado = Intersection.Intersect((Line)Figura1Value,(Ray)Figura2Value,ActualLine);

            else if (Figura2Value is Segment)
            Resultado = Intersection.Intersect((Line)Figura1Value,(Segment)Figura2Value,ActualLine);

            else if (Figura2Value is Line)
            Resultado = Intersection.Intersect((Line)Figura1Value,(Line)Figura2Value,ActualLine);

            else if (Figura2Value is Arco)
            Resultado = Intersection.Intersect((Line)Figura1Value,(Arco)Figura2Value,ActualLine);
            
            else// (Figura2Value is Circunferencia)
            Resultado = Intersection.Intersect((Segment)Figura1Value,(Circunferencia)Figura2Value,ActualLine);


        }
        else if (Figura1Value is Arco)
        {
            if (Figura2Value is Ray)
            Resultado = Intersection.Intersect((Arco)Figura1Value,(Ray)Figura2Value,ActualLine);

            else if (Figura2Value is Segment)
            Resultado = Intersection.Intersect((Arco)Figura1Value,(Segment)Figura2Value,ActualLine);

            else if (Figura2Value is Line)
            Resultado = Intersection.Intersect((Arco)Figura1Value,(Line)Figura2Value,ActualLine);

            else if (Figura2Value is Arco)
            Resultado = Intersection.Intersect((Arco)Figura1Value,(Arco)Figura2Value,ActualLine);
            
            else// (Figura2Value is Circunferencia)
            Resultado = Intersection.Intersect((Arco)Figura1Value,(Circunferencia)Figura2Value,ActualLine);


        }
        else// (Figura1Value is Circunferencia)
        {
            if (Figura2Value is Ray)
            Resultado = Intersection.Intersect((Circunferencia)Figura1Value,(Ray)Figura2Value,ActualLine);

            else if (Figura2Value is Segment)
            Resultado = Intersection.Intersect((Circunferencia)Figura1Value,(Segment)Figura2Value,ActualLine);

            else if (Figura2Value is Line)
            Resultado = Intersection.Intersect((Circunferencia)Figura1Value,(Line)Figura2Value,ActualLine);

            else if (Figura2Value is Arco)
            Resultado = Intersection.Intersect((Circunferencia)Figura1Value,(Arco)Figura2Value,ActualLine);
            
            else// (Figura2Value is Circunferencia)
            Resultado = Intersection.Intersect((Circunferencia)Figura1Value,(Circunferencia)Figura2Value,ActualLine);
        }
        return Resultado;
}
}
