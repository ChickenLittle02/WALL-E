public abstract class UnaryOperator:Node
{
    public Node Expression;

    protected UnaryOperator(Node expression, int actualLine):base(expression.Kind, actualLine)
    {
        Expression = expression;
    }
}