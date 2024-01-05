namespace BackEnd{
public class Mas : UnaryOperator
{
    public Mas(Node expression, int actualLine) : base(expression, actualLine){
        CheckSemantic();
    }

    public override void Evaluate()
    {
        Expression.Evaluate();
        SetValue(Double.Parse(Expression.Value.ToString()));
    }
    public override void CheckSemantic()
    {
        Expression.CheckSemantic();
        if(!(Expression.Kind is NodeKind.Number)) throw new Exception("Debe ser un tipo numerico");
    }
}

public class Menos : UnaryOperator
{
    public Menos(Node expression, int actualLine) : base(expression, actualLine){}
    public override void Evaluate()
    {
        Expression.Evaluate();
        SetValue(-Double.Parse(Expression.Value.ToString()));
    }
    public override void CheckSemantic()
    {
        Expression.CheckSemantic();
        if(!(Expression.Kind is NodeKind.Number)) throw new Exception("Debe ser un tipo numerico");
    }
}}