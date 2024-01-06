

    // public static partial class Intersect
    // {
    //     public static bool IsInSegment(Punto punto, Segmento segmento)
    //     {
    //         double minX = Math.Min(segmento.Punto1.X,segmento.Punto2.X);
    //         double maxX = Math.Max(segmento.Punto1.X,segmento.Punto2.X);
    //         double minY = Math.Min(segmento.Punto1.Y,segmento.Punto2.Y);
    //         double maxY = Math.Max(segmento.Punto1.Y,segmento.Punto2.Y);

    //         // Comprueba si los puntos estan dentro de de cuadro delimitador del segmento
    //         if (punto.X >= minX && punto.X <= maxX && punto.Y >= minY && punto.Y <= maxY)
    //         {
    //             // Ecuacion Parametrica de un segmento
    //             double t = ((punto.X - segmento.Punto1.X) * (segmento.Punto2.X - segmento.Punto1.X) +
    //                         (punto.Y - segmento.Punto1.Y) * (segmento.Punto2.Y - segmento.Punto1.Y)) /
    //                         (Math.Pow(segmento.Punto2.X - segmento.Punto1.X, 2) + Math.Pow(segmento.Punto2.Y - segmento.Punto1.Y, 2));

    //             // revisar si el punto esta contenido en el segmento
    //             if (t >= 0 && t <= 1)
    //             {
    //                 return true;
    //             }
    //         }
    //         return false;
    //     }
    //     public static (double, double) LineEquation(Line recta)
    //     {
    //         //para hallar la ecuacion de una recta se necesita la pendiente y un ounto de la recta para hallar el intercepto con el eje y
    //         double x1 = recta.Punto1.X;
    //         double x2 = recta.Punto2.X;
    //         double y1 = recta.Punto1.Y;
    //         double y2 = recta.Punto2.Y;


    //         //hallar la pendiente
    //         double m = (y2 - y1) / (x2 - x1);

    //         //intersecto con el eje y 
    //         double n = y1 - (m * x1);

    //         return (m, n);

    //     }
    //     public static double PointLineDistance(Punto punto, Line recta)
    //     {
    //         double x1 = recta.Punto1.X;
    //         double y1 = recta.Punto1.Y;
    //         double x2 = recta.Punto2.X;
    //         double y2 = recta.Punto2.X;
    //         double x0 = punto.X;
    //         double y0 = punto.Y;

    //         return Math.Abs((y2 - y1) * x0 - (x2 - x1) * y0 + x2 * y1 - y2 * x1) / Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2));
    //     }


    // }
