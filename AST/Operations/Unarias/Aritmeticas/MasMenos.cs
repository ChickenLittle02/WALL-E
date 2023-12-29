public class Mas : UnaryOperator
{
    public Mas(Node expression, int actualLine) : base(expression, actualLine){}

    public override void Evaluate()
    {
        Expression.Evaluate();
        SetValue(Double.Parse(Expression.Value.ToString()));
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
}