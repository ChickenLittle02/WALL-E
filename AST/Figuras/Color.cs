public class Color : Node
{
    public string IsColor{get; private set;}
    public Color(string Color, int actualLine) : base(NodeKind.Color, actualLine)
    {
        IsColor = Color;

    }

    public override void CheckSemantic()
    {
    }

    public override void Evaluate()
    {
        //Lo que hace es cambiar el pincel del canvas a ese codigo
    }
}