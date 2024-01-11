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

        public override async void Draw(string ID)
        {
            Punto Point1 = (Punto)Punto1.Value;
            Punto Point2 = (Punto)Punto2.Value;
            Point1.CheckSemantic();
            Point1.Evaluate();

            Point2.CheckSemantic();
            Point2.Evaluate();
            if (ID is null)
            {

                await ForDraw._jsRuntime.InvokeVoidAsync("DibujarSegmentoEnCanvas", ForDraw.GetColor(), Point1.X, Point1.Y, Point2.X, Point2.Y);
                // Parámetros: canvasId, puntoInicialX, puntoInicialY, puntoFinalX, puntoFinalY, color, grosor

            }
            else
            {
                await ForDraw._jsRuntime.InvokeVoidAsync("DibujarSegmentoEnCanvasConID", ForDraw.GetColor(), Point1.X, Point1.Y, Point2.X, Point2.Y, ID);
            }
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

        public override async void Draw(string ID)
        {
            Punto Point1 = (Punto)Punto1.Value;
            Punto Point2 = (Punto)Punto2.Value;
            Point1.CheckSemantic();
            Point1.Evaluate();

            Point2.CheckSemantic();
            Point2.Evaluate();

            if (ID is null)
            {
                await ForDraw._jsRuntime.InvokeVoidAsync("DibujarRayoEnCanvas", "myCanvas", ForDraw.GetColor(), Point1.X, Point1.Y, Point2.X, Point2.Y);
            }
            else
            {
                await ForDraw._jsRuntime.InvokeVoidAsync("DibujarRayoEnCanvasConID", "myCanvas", ForDraw.GetColor(), Point1.X, Point1.Y, Point2.X, Point2.Y, ID);
            }

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

        public override async void Draw(string ID)
        {
            Punto Point1 = (Punto)Punto1.Value;
            Punto Point2 = (Punto)Punto2.Value;
            Point1.CheckSemantic();
            Point1.Evaluate();

            Point2.CheckSemantic();
            Point2.Evaluate();
            string color = ForDraw.GetColor();
            if (ID is null)
            {
                await ForDraw._jsRuntime.InvokeVoidAsync("DibujarRectaEnCanvas", color, Point1.X, Point1.Y, Point2.X, Point2.Y);
                // Parámetros: canvasId, puntoInicialX, puntoInicialY, puntoFinalX, puntoFinalY, color, grosor

            }
            else
            {

                await ForDraw._jsRuntime.InvokeVoidAsync("DibujarRectaEnCanvasConID", color, Point1.X, Point1.Y, Point2.X, Point2.Y, ID);
            }
        }

    }
}