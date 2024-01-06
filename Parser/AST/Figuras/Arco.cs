namespace BackEnd
{
    public abstract class Arco : Figura//Recta
    {
        public Node Punto1 { get; private set; }
        public Node Punto2 { get; private set; }
        public Node Centro { get; private set; }
        public Arco(NodeKind kind, int actualLine) : base(kind, actualLine)
        {
            Random RandomCoordinates = new Random();
            Punto1 = new Punto(actualLine);
            Punto2 = new Punto(actualLine);
            Centro = new Punto(actualLine);
        }
        public Arco(Node centro,Node punto1, Node punto2, int actualLine) : base(NodeKind.Arco, actualLine)
        {
            Punto1 = punto1;
            Punto2 = punto2;
            Centro = centro;
        }

        public override void CheckSemantic()
        {
                Punto1.CheckSemantic();
                if (Punto1.Kind is not NodeKind.Punto) throw new Exception("Ambos argumentos deben ser puntos");


                Punto2.CheckSemantic();
                if (Punto2.Kind is not NodeKind.Punto) throw new Exception("Ambos argumentos deben ser puntos");
                Centro.CheckSemantic();
                if (Centro.Kind is not NodeKind.Punto) throw new Exception("Ambos argumentos deben ser puntos");
            
        }

        public override void Evaluate()
        {

            Punto1.Evaluate();
            Punto2.Evaluate();
            Centro.Evaluate();
            SetValue(this);
        }

    }
}