
// public partial class Intersect
// {
//     public static Node LineIntersect(Line recta1, Line recta2, int actualLine)
//     {//este metodo es para obtener la secuencia resultado de intersectar dos rectas

//         Node result = null!;
//         List<Node> Puntos = new List<Node>();

//         var (m1, n1) = LineEquation(recta1);
//         var (m2, n2) = LineEquation(recta2);

//         if (m1 == m2)
//         {
//             //las rectas son paralelas si las pendientes son iguales 
//             //aqui tiene que retornar una secuencia vacia 
//             return result = new FiniteSequence(Puntos, false, actualLine);

//         }
//         else if (m1 == m2 && n1 == n2)
//         {
//             //si las pendientes son iguales y los intercectos con el eje y tambien entonces las rectas son iguales 
//             //aqui tiene que retornar undefined 
//             return new UndefinedSequence(actualLine);
//         }
//         else
//         {
//             //si no pasa algo de esto entonces se calculan los intersectos 
//             double x1 = recta1.Punto1.X;
//             double y1 = recta1.Punto1.Y;
//             double x2 = recta1.Punto2.X;
//             double y2 = recta1.Punto2.Y;

//             double x3 = recta2.Punto1.X;
//             double y3 = recta2.Punto1.Y;
//             double x4 = recta2.Punto2.X;
//             double y4 = recta2.Punto2.Y;

//             double denominador = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

//             double x = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denominador;
//             double y = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denominador;

//             //aqui deberia retornar una secuencia con los Puntos de la interseccion
//             Puntos.Add(new Punto(x, y, actualLine));
//             result = new FiniteSequence(Puntos, false, actualLine);
//             return result;

//         }
//     }
//     public static Node LineCircleIntersect(Line recta, Circunferencia circunferencia, int actualLine)
//     {// este metodo es para intersectar una circunferencia y una recta 
//         var (m, n) = LineEquation(recta);
//         var centro = circunferencia.Centro;
//         var radius = circunferencia.Radio;

//         double centroX = centro.X;
//         double centroY = centro.Y;

//         //Ecuacion de Discriminante : b^2 -4*a*c.
//         double A = 1 + Math.Pow(m, 2);
//         double B = 2 * (m * n - m * centroY - centroX);
//         double C = Math.Pow(centroY, 2) - Math.Pow(radius, 2) + Math.Pow(centroX, 2) - 2 * n * centroY + Math.Pow(n, 2);

//         double discriminant = Math.Pow(B, 2) - 4 * A * C;//calculo del discriminante 

//         // Distancia del centro a la recta
//         double distance = PointLineDistance(centro, recta);

//         List<Node> intersections = new List<Node>();
//         if (distance > radius)
//         {
//             return new FiniteSequence(intersections, false, actualLine);
//         }
//         else if (distance == radius)
//         {
//             double x = (-B) / (2 * A);
//             double y = m * x + n;
//             intersections.Add(new Punto(x, y, actualLine));
//         }
//         else if (discriminant >= 0)
//         {
//             double x1 = (-B + Math.Sqrt(discriminant)) / (2 * A);
//             double x2 = (-B - Math.Sqrt(discriminant)) / (2 * A);

//             double y1 = m * x1 + n;
//             double y2 = m * x2 + n;

//             intersections.Add(new Punto(x1, y1, actualLine));
//             intersections.Add(new Punto(x2, y2, actualLine));
//         }
//         return new FiniteSequence(intersections, false, actualLine);

//     }
//     public static Node SegmentIntersect(Line recta, Segmento segmento,int actualLine)
//     {
//         Line recta2 = new Line(segmento.Punto1,segmento.Punto2,actualLine);

//         object possibleIntersections = LineIntersect(recta, recta2,actualLine);

//         if (possibleIntersections is FiniteSequence)
//         {
//             FiniteSequence seq = (FiniteSequence)possibleIntersections;

//             List<Node> intersections = seq.SequenceValues;

//             foreach (var point in intersections)
//             {
//                 if (!IsInSegment((Punto)point, segmento))
//                 {
//                     intersections.Remove(point);
//                 }
//             }
//             return new FiniteSequence(intersections,false ,actualLine);
//         }
//         // Este es el caso en que la recta y el segmento esten superpuestos
//         else return new UndefinedSequence(actualLine);
//     }
// }


