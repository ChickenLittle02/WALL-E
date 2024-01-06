// public static partial class Intersect
// {
//     public static Node IntersectarCircunferencia(Circunferencia circunferencia1, Circunferencia circunferencia2, int actualLine)
//     {
//         List<Node> intersections = new List<Node>(); 

//         double x1 = circunferencia1.Centro.X;
//         double y1 = circunferencia1.Centro.Y;
//         double r1 = circunferencia1.Radio;

//         double x2 = circunferencia2.Centro.X;
//         double y2 = circunferencia2.Centro.Y;
//         double r2 = circunferencia1.Radio;

//         double distancia = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

//         if (x1 == x2 && y1 == y2 && r1 == r2)
//         {

//             return new UndefinedSequence(actualLine);
//         }
//         else if (distancia > r1 + r2 || distancia < Math.Abs(r1 - r2) || distancia == 0)

//         {
//             return new FiniteSequence(new List<Node>(), false,actualLine); // las circunferencias no se intersectan en ningun punto
//         }

//         else if (distancia == r1 + r2 || distancia == Math.Abs(r1 - r2))
//         {
//             // Las circunferencias targentes solo se intersecan en un punto
//             double x = (r1 * x2 + r2 * x1) / (r1 + r2);
//             double y = (r1 * y2 + r2 * y1) / (r1 + r2);
//             intersections.Add(new Punto(x, y,actualLine));
//         }
//         else
//         {
//             // Las circunferencias se intersecan en dos puntos 
//             double a = (Math.Pow(r1, 2) - Math.Pow(r2, 2) + Math.Pow(distancia, 2)) / (2 * distancia);
//             double h = Math.Sqrt(Math.Pow(r1, 2) - Math.Pow(a, 2));

//             double x = x1 + (a * (x2 - x1)) / distancia;
//             double y = y1 + (a * (y2 - y1)) / distancia;

//             double intersectX1 = x + (h * (y2 - y1)) / distancia;
//             double intersectY1 = y - (h * (x2 - x1)) / distancia;

//             double intersectX2 = x - (h * (y2 - y1)) / distancia;
//             double intersectY2 = y + (h * (x2 - x1)) / distancia;

//             intersections.Add(new Punto(intersectX1, intersectY1,actualLine));
//             intersections.Add(new Punto(intersectX2, intersectY2,actualLine));
//         }
//         return new FiniteSequence(intersections,false ,actualLine);
//     }
//     public static Node CircleSegmentIntersect(Segmento segment, Circunferencia circle,int actualLine)
//     {
//         Line line = new Line(segment.Punto1, segment.Punto2,actualLine);
//         object possibleIntersections = LineCircleIntersect(line, circle,actualLine);
//         if (possibleIntersections is FiniteSequence)
//         {
//             FiniteSequence seq = (FiniteSequence)possibleIntersections;
//             List<Node> intersections = seq.SequenceValues;

//             foreach (var point in intersections.ToList())
//             {
//                 if (!IsInSegment((Punto)point, segment))
//                 {
//                     intersections.Remove(point);
//                 }
//             }
//             return new FiniteSequence(intersections,false , actualLine);
//         }
//         else return new FiniteSequence(new List<Node >(),false ,actualLine);
//     }
// }
