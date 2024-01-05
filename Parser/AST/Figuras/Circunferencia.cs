namespace BackEnd{
public class Circunferencia:Node
{
    public Punto Centro{get;private set;}
    public double Radio{get;private set;}
    public string Identifier{get; private set;}
    public Circunferencia(int actualLine) : base(NodeKind.Circunferencia, actualLine)
    {
        Random RandomCoordinates = new Random();
        Centro = new Punto(RandomCoordinates.Next(100),RandomCoordinates.Next(100),actualLine);
        Radio = RandomCoordinates.Next(100);

    }
public Circunferencia(string Identifier, int actualLine) : base(NodeKind.Circunferencia, actualLine)
    {
        Random RandomCoordinates = new Random();
        Centro = new Punto(RandomCoordinates.Next(100),RandomCoordinates.Next(100),actualLine);
        Radio = RandomCoordinates.Next(100);
        this.Identifier = Identifier;

    }

    public Circunferencia(Node centro, double Radio, int actualLine) : base(NodeKind.Circunferencia, actualLine)
    {
        centro.CheckSemantic();
        centro.Evaluate();
        if(centro.Value is not Punto) throw new Exception("La expresion recibida debe ser un punto");
        Centro = (Punto)centro;
        this.Radio = Radio;
    }
    public Circunferencia(Node centro, double Radio, string Identifier, int actualLine) : base(NodeKind.Circunferencia, actualLine)
    {
        centro.CheckSemantic();
        centro.Evaluate();
        if(centro.Value is not Punto) throw new Exception("La expresion recibida debe ser un punto");
        Centro = (Punto)centro;
        this.Radio = Radio;
        this.Identifier = Identifier;
    }

    public override void CheckSemantic()
    {
    }

    public override void Evaluate()
    {
        SetValue(this);
    }
}}