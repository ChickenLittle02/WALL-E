namespace BackEnd
{
    public class Measure : Node
    {
        public Node Point1 { get; private set; }
        public Node Point2 { get; private set; }
        public double Value { get; private set; }

        public Measure(Node Point1, Node Point2, int actualLine) : base(NodeKind.Number, actualLine)
        {
            this.Point1 = Point1;
            this.Point2 = Point2;
        }

        public Measure(double value, int actualLine) : base(NodeKind.Number, actualLine)
        {
            Value = value - value % 1;
        }

        public override void CheckSemantic()
        {
            if (Point1 is not null)
            {
                Point1.CheckSemantic();
                if (Point1.Value is not Punto) new Error(ErrorKind.Semantic, $"Measure function only recieve point", ActualLine);
            }
            if (Point2 is not null)
            {
                Point2.CheckSemantic();
                if (Point2.Value is not Punto) new Error(ErrorKind.Semantic, $"Measure function only recieve point", ActualLine);
            }
        }

        public override void Evaluate()
        {
            if (Point1 is not null)
            {
            Point1.Evaluate();
            }
            if (Point2 is not null)
            {
            Point2.Evaluate();
            }
            SetValue(new BasicExpression(Distancia(), NodeKind.Number, ActualLine));
        }

        private double Distancia()
        {
            Punto Punto1 = (Punto)Point1.Value;

            Punto Punto2 = (Punto)Point2.Value;
            double distancia = Math.Sqrt(Math.Pow(Punto1.X - Punto2.X, 2) + Math.Pow(Punto1.Y - Punto2.Y, 2));
            distancia = distancia - distancia % 1;
            return distancia;
        }
    }
}