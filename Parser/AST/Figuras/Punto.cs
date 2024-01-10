using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace BackEnd
{
    public class Punto : Figura
    {
        public double X { get; private set; }
        public Node X_Value { get; private set; }
        public Node Y_Value { get; private set; }
        public double Y { get; private set; }

        public Punto(int actualLine) : base(NodeKind.Punto, actualLine)
        {
            Random RandomCoordinate = new Random();
            X = RandomCoordinate.Next(400);
            Y = RandomCoordinate.Next(400);//Este numero seria el tope, el que se escoge es el limite del canvas
        }
        public Punto(string Identifier, int actualLine) : base(Identifier, NodeKind.Punto, actualLine)
        {
            Random RandomCoordinate = new Random();
            X = RandomCoordinate.Next(400);
            Y = RandomCoordinate.Next(400);//Este numero seria el tope, el que se escoge es el limite del canvas
        }

        public Punto(Node X, Node Y, int actualLine) : base(NodeKind.Punto, actualLine)
        {
            this.X_Value = X;
            this.Y_Value = Y;//Este numero seria el tope, el que se escoge es el limite del canvas
        }
        public Punto(double X, double Y, int actualLine) : base(NodeKind.Punto, actualLine)
        {
            this.X = X;
            this.Y = Y;//Este numero seria el tope, el que se escoge es el limite del canvas
        }
        public Punto(Node X, Node Y, string Identifier, int actualLine) : base(Identifier, NodeKind.Punto, actualLine)
        {
            this.X_Value = X;
            this.Y_Value = Y;//Este numero seria el tope, el que se escoge es el limite del canvas
        }
        public override void CheckSemantic()
        {
            if (X_Value is not null)
            {
                X_Value.CheckSemantic();
                if (X_Value.Kind is not NodeKind.Number) new Error(ErrorKind.Semantic,"First argument must be a number",ActualLine);
            }
            if (Y_Value is not null)
            {
                Y_Value.CheckSemantic();
                if (Y_Value.Kind is not NodeKind.Number) new Error(ErrorKind.Semantic,"Second argument must be a number",ActualLine);
            }
        }
        public static bool TryParse(object Object, out Punto Casteo)
        {
            if (Object is Punto)
            {
                Casteo = (Punto)Object;
                return true;

            }
            else
            {
                Casteo = null;
                return false;
            }

        }

        public override void Evaluate()
        {
            if (X_Value is not null)
            {
                X_Value.Evaluate();
                double value;
                if (!Double.TryParse(X_Value.Value.ToString(), out value)) throw new Exception("Debe ser de tipo numerico");
                X = value;
            }
            if (Y_Value is not null)
            {
                Y_Value.Evaluate();
                double value;
                if (!Double.TryParse(Y_Value.Value.ToString(), out value)) throw new Exception("Debe ser de tipo numerico");
                Y = value;
            }
            SetValue(this);
        }


        public override string ToString()
        {
            return $"{Identifier}\n({X},{Y});";
        }

        public async override void Draw()
        {
        
        await ForDraw._jsRuntime.InvokeVoidAsync("DibujarPuntoEnCanvas",ForDraw.GetColor(), X, Y);
        }
    }
}