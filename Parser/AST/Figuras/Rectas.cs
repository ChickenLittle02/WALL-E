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

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Evaluate()
        {
            SetValue(this);
            //Y además coge y da la orden de dibujar un segmento
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

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Evaluate()
        {
            SetValue(this);
            //Y además coge y da la orden de dibujar una semirrecta
        }
    }

    public class Line : FigurasConDosPuntos //Semirrecta
    {
        public Line(int actualLine) : base(NodeKind.Line, actualLine)
        {
        }

        public Line(Node punto1, Node punto2, int actualLine) : base(punto1, punto2, NodeKind.Line, actualLine)
        {
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Evaluate()
        {
            SetValue(this);
            //Y además coge y da la orden de dibujar una semirrecta
        }
    }
}