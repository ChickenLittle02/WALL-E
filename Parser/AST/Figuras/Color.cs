namespace BackEnd{
public class Color : Node
{
    public string IsColor { get; private set; }
    public Color(string Color, int actualLine) : base(NodeKind.Color, actualLine)
    {
        IsColor = Color;

    }

    public override void CheckSemantic()
    {
        switch (IsColor)
        {
            case "blue":
                break;
            case "red":
                break;
            case "yellow":
                break;
            case "green":
                break;
            case "cyan":
                break;
            case "magenta":
                break;
            case "white":
                break;
            case "gray":
                break;
            case "black":
                break;
            default:
                throw new Exception("No es un color valido");


        }
    }

    public override async void Evaluate()
    {
        ForDraw.Colors.Push(IsColor);
    }
}
public class Restore : Node
{
    public Restore(int actualLine) : base(NodeKind.Color, actualLine)
    {
    }

    public override void CheckSemantic()
    {
    }

    public override async void Evaluate()
    {
        if(ForDraw.Colors.Count != 0) ForDraw.Colors.Pop();
        
    }
}
}