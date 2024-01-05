namespace BackEnd{
public class AndExpression : BinaryOperations
{
    public AndExpression(Node leftNode, Node rightNode, NodeKind kind, int actualLine) : base(leftNode, rightNode, kind, actualLine)
    {
    }

    public override void CheckSemantic()
    {
        LeftNode.CheckSemantic();
        RightNode.CheckSemantic();
        SetKind(NodeKind.Number);        
    }

    public override void Evaluate()
    {
        LeftNode.Evaluate();
        bool left = ForBoolean.ConvertToBool(LeftNode.Value);
        RightNode.Evaluate();
        bool right = ForBoolean.ConvertToBool(RightNode.Value);
        SetValue(ForBoolean.ToDoubleBooleanValue(left&right));

    }
}

public class OrExpression : BinaryOperations
{
    public OrExpression(Node leftNode, Node rightNode, NodeKind kind, int actualLine) : base(leftNode, rightNode, kind, actualLine)
    {
    }

    public override void CheckSemantic()
    {
        LeftNode.CheckSemantic();
        RightNode.CheckSemantic();
        SetKind(NodeKind.Number);        
    }

    public override void Evaluate()
    {
        LeftNode.Evaluate();
        bool left = ForBoolean.ConvertToBool(LeftNode.Value);
        RightNode.Evaluate();
        bool right = ForBoolean.ConvertToBool(RightNode.Value);
        SetValue(ForBoolean.ToDoubleBooleanValue(left||right));

    }
}}