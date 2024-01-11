using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace BackEnd
{
    public class Arco : Figura//Recta
    {
        public Node Punto1 { get; private set; }
        public Node Punto2 { get; private set; }
        public Node Centro { get; private set; }
        public double radio { get; set; }
        public Node Radio { get; set; }
        public Arco(int actualLine) : base(NodeKind.Arco, actualLine)
        {
            Random RandomCoordinates = new Random();
            Punto1 = new Punto(actualLine);
            Punto2 = new Punto(actualLine);
            Centro = new Punto(actualLine);
            radio = RandomCoordinates.Next(30);
        }
        public Arco(Node centro, Node punto1, Node punto2, Node radio, int actualLine) : base(NodeKind.Arco, actualLine)
        {
            Punto1 = punto1;
            Punto2 = punto2;
            Centro = centro;
            Radio = radio;
        }

        public override void CheckSemantic()
        {
            if (Punto1 is not null)
            {
                Punto1.CheckSemantic();
                if (Punto1.Kind is not NodeKind.Punto) new Error(ErrorKind.Semantic, "Second argument of arc declaration must be a point", ActualLine);

            }
            if (Punto2 is not null)
            {
                Punto2.CheckSemantic();
                if (Punto2.Kind is not NodeKind.Punto) new Error(ErrorKind.Semantic, "Third argument of arc declaration must be a point", ActualLine);

            }
            if (Centro is not null)
            {
                Centro.CheckSemantic();
                if (Centro.Kind is not NodeKind.Punto) new Error(ErrorKind.Semantic, "First argument of arc declaration must be a point", ActualLine);
            }
            if (Radio is not null)
            {
                Radio.CheckSemantic();
                if (Radio.Kind is not NodeKind.Number) new Error(ErrorKind.Semantic, "Fourth argument of circle declaration must be a measure", ActualLine);
            }

        }

        public override void Evaluate()
        {
            if (Punto1 is not null)
            {
                Punto1.Evaluate();
            }
            if (Punto2 is not null)
            {
                Punto2.Evaluate();
            }
            if (Centro is not null)
            {
                Centro.Evaluate();
            }
            if (Radio is not null)
            {
                Radio.Evaluate();
                radio = (double)Radio.Value;
            }
            SetValue(this);
        }

        public override async void Draw(string ID)
        {
            Punto ValueP1 = (Punto)Punto1.Value;
            Punto ValueP2 = (Punto)Punto2.Value;
            Punto ValueC = (Punto)Centro.Value;

            string color = ForDraw.GetColor();

            if (ID is null)
            {
                await ForDraw._jsRuntime.InvokeVoidAsync("DibujarArcoEnCanvas", color, ValueC.X, ValueC.Y, ValueP1.X, ValueP1.Y, ValueP2.X, ValueP2.Y, radio);
            }
            else
            {
                await ForDraw._jsRuntime.InvokeVoidAsync("DibujarArcoEnCanvasConID", color, ValueC.X, ValueC.Y, ValueP1.X, ValueP1.Y, ValueP2.X, ValueP2.Y, radio,ID);

            }
        }
        public override string ToString()
        {
            Punto1.Start();
            Punto2.Start();
            Centro.Start();
            Punto Center, Point1, Point2;
            Punto.TryParse(Centro.Value, out Center); Punto.TryParse(Punto1.Value, out Point1); Punto.TryParse(Punto2.Value, out Point2);

            return $"Centro({Center.X},{Center.Y}),({Point1.X},{Point1.Y});({Point2.X},{Point2.Y})";
        }
    }
}