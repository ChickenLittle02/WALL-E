using System.Linq.Expressions;

public class Not : UnaryOperator
{
    public Not(Node expression) : base(expression)
    {
        Kind = NodeKind.Boolean;
    }

    public override void Evaluate()
    {
        Expression.Evaluate();
        Value = !(bool)Expression.Value;
    }
}