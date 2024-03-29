namespace BackEnd
{
    public abstract class FigurasConDosPuntos : Figura//Recta
    {
        public Node Punto1 { get; private set; }
        public Node Punto2 { get; private set; }
        public FigurasConDosPuntos(NodeKind kind, int actualLine) : base(kind, actualLine)
        {
            Random RandomCoordinates = new Random();
            Punto1 = new Punto(actualLine);
            Punto2 = new Punto(actualLine);
        }
        public FigurasConDosPuntos(Node punto1, Node punto2, NodeKind kind, int actualLine) : base(kind, actualLine)
        {
            Punto1 = punto1;
            Punto2 = punto2;
        }

        public override void CheckSemantic()
        {
            Punto1.CheckSemantic();
            if (Punto1.Kind is not NodeKind.Punto&&Punto1.Kind is not NodeKind.Temp) new Error(ErrorKind.Semantic,"First argument must be a point",Punto1.ActualLine);



            Punto2.CheckSemantic();
            if (Punto2.Kind is not NodeKind.Punto && Punto2.Kind is not NodeKind.Temp) new Error(ErrorKind.Semantic,"Second argument must be a point",Punto2.ActualLine);

        }

        public override void Evaluate()
        {

            Punto1.Evaluate();
            Punto2.Evaluate();
            SetValue(this);
        }
        public override string ToString()
        {
            Punto Point1 = (Punto)this.Punto1.Value;

            Punto Point2 = (Punto)this.Punto2.Value;
            return $"{Identifier} ({Point1.X},{Point1.Y});({Point2.X},{Point2.Y})";
        }

    }
}