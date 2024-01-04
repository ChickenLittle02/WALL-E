public class Print : SystemFunction
{
    public Print(Node Figura, int actualLine) : base(Figura, actualLine)
    {
    }

    public override void Evaluate()
    {
        base.Evaluate();
        if(Value is null) System.Console.WriteLine("null");
        else System.Console.WriteLine(Value);//O la manera real seria convertirlo a string y pasarselo como texto a la web
    }
}