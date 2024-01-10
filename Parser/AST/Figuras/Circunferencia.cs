using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace BackEnd
{
    public class Circunferencia : Figura
    {
        public Node Centro { get; private set; }
        public Node Radio { get; private set; }
        public double radio { get; private set; }
        public Circunferencia(int actualLine) : base(NodeKind.Circunferencia, actualLine)
        {
            Random RandomCoordinates = new Random();
            Centro = new Punto(actualLine);
            radio = RandomCoordinates.Next(30);

        }
        public Circunferencia(string Identifier, int actualLine) : base(Identifier, NodeKind.Circunferencia, actualLine)
        {
            Random RandomCoordinates = new Random();
            Centro = new Punto(actualLine);
            radio = RandomCoordinates.Next(30);

        }

        public Circunferencia(Node centro, Node Radio, int actualLine) : base(NodeKind.Circunferencia, actualLine)
        {
            Centro = centro;
            this.Radio = Radio;
        }
        public Circunferencia(Node centro, Node Radio, string Identifier, int actualLine) : base(Identifier, NodeKind.Circunferencia, actualLine)
        {
            Centro = centro;
            this.Radio = Radio;
        }

        public override void CheckSemantic()
        {
            Centro.CheckSemantic();
            if (Centro is not null)
            {
                Centro.CheckSemantic();
                if (Centro.Kind is not NodeKind.Punto)  new Error(ErrorKind.Semantic,"First argument of circle declaration must be a point",ActualLine);
                throw new Exception("Debe ser de tipo centro");
            }
            if (Radio is not null)
            {
                Radio.CheckSemantic();
                if (Radio.Kind is not NodeKind.Number) new Error(ErrorKind.Semantic,"First argument of circle declaration must be a measure",ActualLine);
            }

        }

        public override void Evaluate()
        {
            if (Centro is not null)
            {
                Centro.Evaluate();
                Punto value;
            }
            if (Radio is not null)
            {
                Radio.Evaluate();
                double value;
                if (!Double.TryParse(Radio.Value.ToString(), out value)) new Error(ErrorKind.Semantic,"Unexpected error: this must be a measure",ActualLine);
                radio = value;
            }
            SetValue(this);
        }
        public override string ToString()
        {
            Punto Center;
            Punto.TryParse(Centro.Value, out Center);

            return $"Centro({Center.X},{Center.Y});{radio}";
        }
        public override async void Draw()
        {
            Punto value;
            if (!Punto.TryParse(Centro.Value, out value)) new Error(ErrorKind.Semantic,"Unexpected error: this must be a point",ActualLine);
            string color = ForDraw.GetColor();
            await ForDraw._jsRuntime.InvokeVoidAsync("DibujarCircunferenciaEnCanvas", color, value.X, value.Y, radio);
        }
    }
}
