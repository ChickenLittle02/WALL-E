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

        public Punto(int actualLine) : base( NodeKind.Punto, actualLine)
        {
            Random RandomCoordinate = new Random();
            X = RandomCoordinate.Next(100);
            Y = RandomCoordinate.Next(100);//Este numero seria el tope, el que se escoge es el limite del canvas
        }
        public Punto( string Identifier, int actualLine) : base(Identifier, NodeKind.Punto, actualLine)
        {
            Random RandomCoordinate = new Random();
            X = RandomCoordinate.Next(100);
            Y = RandomCoordinate.Next(100);//Este numero seria el tope, el que se escoge es el limite del canvas
        }

        public Punto( Node X, Node Y, int actualLine) : base(NodeKind.Punto, actualLine)
        {
            this.X_Value = X;
            this.Y_Value = Y;//Este numero seria el tope, el que se escoge es el limite del canvas
        }
        public Punto( Node X, Node Y, string Identifier, int actualLine) : base(Identifier,NodeKind.Punto, actualLine)
        {
            this.X_Value = X;
            this.Y_Value = Y;//Este numero seria el tope, el que se escoge es el limite del canvas
        }
        public override void CheckSemantic()
        {
            if (X_Value is not null)
            {
                X_Value.CheckSemantic();
                if (X_Value.Kind is not NodeKind.Number) throw new Exception("Debe ser de tipo numerico");
            }
            if (Y_Value is not null)
            {
                Y_Value.CheckSemantic();
                if (Y_Value.Kind is not NodeKind.Number) throw new Exception("Debe ser de tipo numerico");
            }
        }
        public static bool TryParse(object Object, out Punto Casteo)
        {
            if(Object is Punto)
            {
                Casteo = (Punto)Object;
                return true;

            } else{
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
                if(!Double.TryParse(X_Value.Value.ToString(), out value)) throw new Exception("Debe ser de tipo numerico");
            }
            if (Y_Value is not null)
            {
                Y_Value.Evaluate();
                double value;
                if(!Double.TryParse(Y_Value.Value.ToString(), out value)) throw new Exception("Debe ser de tipo numerico");
            }
            SetValue(this);
            Draw();
        }

        
        public override string ToString()
        {
            return $"{Identifier}\n({X},{Y});";
        }

        public override void Draw()
        {
            DibujarPuntoEnCanvas(X,Y);
        }

        public async Task DibujarPuntoEnCanvas(double x, double y)
        {
            await ForDraw._jsRuntime.InvokeVoidAsync("dibujarPuntoEnCanvas", x, y);
        }
    }
}
