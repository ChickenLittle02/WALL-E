using System.Runtime.InteropServices;

namespace BackEnd;
public partial class Intersection
{
    // intersectos entre Arco y Punto esta hecho en el archivo "DePunto.cs"

    //intersectos entre Arco y recta esta hecho en el archivo "DeLinea.cs"

    //intersectos entre Arco y segmento esta hecho en el archivo "DeSegmento.cs"

    //intersectos entre Arco y Rayo esta hecho en el archivo "DeRayo.cs"

    //intersectos entre Arco y Circunferenca esta hecho en el archivo "DeCircunferencia.cs"

    public static Sequence Intersect(Arco arc1, Arco arc2, int actualLine)
    {
        Circunferencia circle = new(arc1.Centro, arc1.Radio, actualLine);
        Sequence posibleInterseccion = Intersect(arc2, circle, actualLine);
        if (posibleInterseccion is FiniteSequence)
        {
            FiniteSequence seq = (FiniteSequence)posibleInterseccion;
            List<Node> intersecciones = seq.GetELements;
            List<Node> validintersections = new List<Node>();
            foreach (Punto point in intersecciones)
            {
                if (IsInArc(point, arc1) && IsInArc(point, arc2))
                {
                    validintersections.Add(point);
                }
            }
            return new FiniteSequence(validintersections, false, actualLine);
        }
        else return posibleInterseccion;
    }



}
