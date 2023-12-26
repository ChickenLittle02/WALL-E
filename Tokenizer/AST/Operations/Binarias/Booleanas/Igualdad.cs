public class Igual : BinaryOperations
{
    public Igual(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {

        Kind = NodeKind.Boolean;
    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())==Double.Parse(RightNode.Value.ToString());   
    }
}

public class Distinto : BinaryOperations
{
    public Distinto(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {

        Kind = NodeKind.Boolean;
    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())!=Double.Parse(RightNode.Value.ToString());
        
    }
}