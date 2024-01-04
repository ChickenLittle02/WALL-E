using System.Linq.Expressions;

public class SystemFunction : Node
{//Es una funcion que devuelve una figura
    public Node Expression {get; private set;}
    public SystemFunction(Node Figura, int actualLine) : base(Figura.Kind, actualLine)
    {
        Expression = Figura;
    }

    public override void CheckSemantic()
    {
        Expression.CheckSemantic();
    }

    public override void Evaluate()
    {
        Expression.Evaluate();
        SetValue(Expression.Value);
    }
}