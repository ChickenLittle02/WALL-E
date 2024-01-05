namespace BackEnd{
public class Punto:Figura
{
    public double X{get; set;}
    public double Y{get; set;}
    public string Identifier{get; set;}

    public Punto(int actualLine) : base(NodeKind.Punto, actualLine)
    {
        Random RandomCoordinate = new Random();
        X = RandomCoordinate.Next(100);
        Y = RandomCoordinate.Next(100);//Este numero seria el tope, el que se escoge es el limite del canvas
    }
    public Punto(string Identifier, int actualLine) : base(NodeKind.Punto, actualLine)
    {
        Random RandomCoordinate = new Random();
        X = RandomCoordinate.Next(100);
        Y = RandomCoordinate.Next(100);//Este numero seria el tope, el que se escoge es el limite del canvas
    }

    public Punto(double X, double Y, int actualLine) : base(NodeKind.Punto, actualLine)
    {
        this.X = X;
        this.Y = Y;//Este numero seria el tope, el que se escoge es el limite del canvas
    }
    public Punto(double X, double Y, string Identifier, int actualLine) : base(NodeKind.Punto, actualLine)
    {
        this.X = X;
        this.Y = Y;//Este numero seria el tope, el que se escoge es el limite del canvas
        this.Identifier = Identifier;
    }
    public override void CheckSemantic()
    {
    }

    public override void Evaluate()
    {
        SetValue(this);
    }
    public override string ToString()
    {
        return$"{Identifier}/n({X},{Y});";
    }
}}