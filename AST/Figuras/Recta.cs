public class Recta:Figura
{
    public Punto Punto1{get; private set;}
    public Punto Punto2{get; private set;}
    public Recta(int actualLine) : base(NodeKind.Recta, actualLine)
    {
        
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