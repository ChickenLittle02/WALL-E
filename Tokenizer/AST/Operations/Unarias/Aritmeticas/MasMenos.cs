public class Mas : UnaryOperator
{
    public Mas(Node expression) : base(expression)
    {
        Kind = NodeKind.Number;
    }

    public override void Evaluate()
    {
        Expression.Evaluate();
        Value = Double.Parse(Expression.Value.ToString());
    }
}

public class Menos : UnaryOperator
{
    public Menos(Node expression) : base(expression)
    {
        Kind = NodeKind.Number;
    }

    public override void Evaluate()
    {
        Expression.Evaluate();
        Value = -Double.Parse(Expression.Value.ToString());
    }
}