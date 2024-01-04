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

    public override void Evaluate()
    {
        //Lo que hace es cambiar el pincel del canvas a ese codigo
        //Y agregar el color a la lista
    }
}