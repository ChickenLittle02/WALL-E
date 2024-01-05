namespace BackEnd{
public class Measure : Node
{
    public Node Point1{get; private set;}
    public Node Point2{get; private set;}

    public Measure(Node Point1,Node Point2, int actualLine) : base(NodeKind.Number, actualLine)
    {
        this.Point1 = Point1;
        this.Point2 = Point2;
    }

    public override void CheckSemantic()
    {
        Point1.CheckSemantic();
        Point1.Evaluate();
        if(Point1.Value is not Punto) throw new Exception("La funcion measure solo recibe puntos");
        Point2.CheckSemantic();
        Point2.Evaluate();
        if(Point2.Value is not Punto) throw new Exception("La funcion measure solo recibe puntos");
    }

    public override void Evaluate()
    {
        SetValue(new BasicExpression(Distancia(),NodeKind.Number,ActualLine));
    }

    private double Distancia()
    {
        Punto Punto1 = (Punto)Point1.Value;
        
        Punto Punto2 = (Punto)Point2.Value;
        double distancia = Math.Sqrt(Math.Pow(Punto1.X-Punto2.X,2)+Math.Pow(Punto1.Y-Punto2.Y,2));
        distancia = distancia -distancia%1;
        return distancia;
    }
}}