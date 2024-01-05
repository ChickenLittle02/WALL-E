namespace BackEnd{
public class Segmento : Line
{
    public Segmento(int actualLine) : base(actualLine)
    {
    }
    public override void Evaluate()
    {
        SetValue(this);
        //Y además coge y da la orden de dibujar un segmento
    }
}

public class Semirrecta : Line
{
    public Semirrecta(int actualLine) : base(actualLine)
    {
    }
    public override void Evaluate()
    {
        SetValue(this);
        //Y además coge y da la orden de dibujar una semirrecta
    }
}}