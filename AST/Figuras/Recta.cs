public class Line:Figura//Recta
{
    public Punto Punto1{get; private set;}
    public Punto Punto2{get; private set;}
    public string Identifier{get; private set;}
    public Line(int actualLine) : base(NodeKind.Recta, actualLine)
    {Random RandomCoordinates = new Random();
        Punto1 = new Punto(RandomCoordinates.Next(100),RandomCoordinates.Next(100),actualLine);
        Punto2 = new Punto(RandomCoordinates.Next(100),RandomCoordinates.Next(100),actualLine);
    }
    public Line(string Identifier, int actualLine) : base(NodeKind.Recta, actualLine)
    {Random RandomCoordinates = new Random();
        Punto1 = new Punto(RandomCoordinates.Next(100),RandomCoordinates.Next(100),actualLine);
        Punto2 = new Punto(RandomCoordinates.Next(100),RandomCoordinates.Next(100),actualLine);
        this.Identifier = Identifier;
    }
    public Line(Punto punto1, Punto punto2, int actualLine) : base(NodeKind.Recta, actualLine)
    {
        Punto1 = punto1;
        Punto2 = punto2;
    }
    public Line(Punto punto1, Punto punto2, string Identifier, int actualLine) : base(NodeKind.Recta, actualLine)
    {
        Punto1 = punto1;
        Punto2 = punto2;
        this.Identifier = Identifier;
    }

    public override void CheckSemantic()
    {
        throw new NotImplementedException();
    }

    public override void Evaluate()
    {
        throw new NotImplementedException();
    }
}