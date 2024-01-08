using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace BackEnd
{
    public class Segment : FigurasConDosPuntos
    {
        public Segment(int actualLine) : base(NodeKind.Segment, actualLine)
        {
        }
        public Segment(Node punto1, Node punto2, int actualLine) : base(punto1, punto2, NodeKind.Segment, actualLine)
        {
        }

        public override async void Draw()
        {
            Punto Point1 = (Punto)Punto1.Value;
            Punto Point2 = (Punto)Punto2.Value;
            Point1.CheckSemantic();
            Point1.Evaluate();
            
            Point2.CheckSemantic();
            Point2.Evaluate();

        await ForDraw._jsRuntime.InvokeVoidAsync("DibujarSegmentoEnCanvas", Point1.X, Point1.Y,Point2.X,Point2.Y);
        // Parámetros: canvasId, puntoInicialX, puntoInicialY, puntoFinalX, puntoFinalY, color, grosor
        }


    }

    public class Ray : FigurasConDosPuntos //Semirrecta
    {
        public Ray(int actualLine) : base(NodeKind.Ray, actualLine)
        {
        }

        public Ray(Node punto1, Node punto2, int actualLine) : base(punto1, punto2, NodeKind.Ray, actualLine)
        {
        }

        public override async void Draw()
        {
            Punto Point1 = (Punto)Punto1.Value;
            Punto Point2 = (Punto)Punto2.Value;
            Point1.CheckSemantic();
            Point1.Evaluate();
            
            Point2.CheckSemantic();
            Point2.Evaluate();
            
        await ForDraw._jsRuntime.InvokeVoidAsync("DibujarRayoEnCanvas", "myCanvas", Point1.X, Point1.Y, Point2.X, Point2.Y);
        

        }


    }

    public class Line : FigurasConDosPuntos //Recta
    {
        public Line(int actualLine) : base(NodeKind.Line, actualLine)
        {
        }

        public Line(Node punto1, Node punto2, int actualLine) : base(punto1, punto2, NodeKind.Line, actualLine)
        {
        }

        public override async void Draw()
        {
            Punto Point1 = (Punto)Punto1.Value;
            Punto Point2 = (Punto)Punto2.Value;
            Point1.CheckSemantic();
            Point1.Evaluate();
            
            Point2.CheckSemantic();
            Point2.Evaluate();

        await ForDraw._jsRuntime.InvokeVoidAsync("DibujarRectaEnCanvas", Point1.X, Point1.Y,Point2.X,Point2.Y);
        // Parámetros: canvasId, puntoInicialX, puntoInicialY, puntoFinalX, puntoFinalY, color, grosor
        }

    }
}