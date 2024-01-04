using System.Drawing;

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
    public Line(Node punto1, Node punto2, int actualLine) : base(NodeKind.Recta, actualLine)
    {
        punto1.CheckSemantic();
        punto1.Evaluate();
        punto2.CheckSemantic();
        punto2.Evaluate();
        if(punto1 is not Punto && punto2 is not Punto) throw new Exception("Ambos argumentos deben ser puntos");
        Punto1 = (Punto)punto1;
        Punto2 = (Punto)punto2;
    }
    public Line(Node punto1, Node punto2, string Identifier, int actualLine) : base(NodeKind.Recta, actualLine)
    {
        punto1.CheckSemantic();
        punto1.Evaluate();
        punto2.CheckSemantic();
        punto2.Evaluate();
        if(punto1 is not Punto && punto2 is not Punto) throw new Exception("Ambos argumentos deben ser puntos");
        Punto1 = (Punto)punto1;
        Punto2 = (Punto)punto2;
        this.Identifier = Identifier;
    }

    public override void CheckSemantic()
    {
    }

    public override void Evaluate()
    {
        SetValue(this);
    }
}