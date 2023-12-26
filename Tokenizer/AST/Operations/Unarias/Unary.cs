public abstract class UnaryOperator:Node
{
    public Node Expression;

    protected UnaryOperator(Node expression)
    {
        Expression = expression;
    }
}