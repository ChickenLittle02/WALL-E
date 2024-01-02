public class LetExpression:Node
{
    List<Node> AllExpression;
    Node ReturnExpression;
    public LetExpression(List<Node> allExpression, Node returnExpression,int actualLine):base(returnExpression.Kind,actualLine)
    {
        AllExpression = allExpression;
        ReturnExpression = returnExpression;
    }

    public override void Evaluate()
    {
        for(int i = 0; i<AllExpression.Count;i++) AllExpression[i].Evaluate();
        ReturnExpression.Evaluate();
        SetValue(ReturnExpression.Value);
    }
    public override void CheckSemantic()
    {
        for(int i = 0; i<AllExpression.Count;i++) AllExpression[i].CheckSemantic();
        ReturnExpression.CheckSemantic();
        SetKind(ReturnExpression.Kind);

    }
}