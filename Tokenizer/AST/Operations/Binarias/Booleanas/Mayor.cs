public class Mayor : BinaryOperations
{
    public Mayor(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {
        Kind = NodeKind.Boolean;

    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())>Double.Parse(RightNode.Value.ToString());
        
    }
}

public class MayorIgual : BinaryOperations
{
    public MayorIgual(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {

        Kind = NodeKind.Boolean;
    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())>=Double.Parse(RightNode.Value.ToString());;
        
    }
}