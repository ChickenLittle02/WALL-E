public class Menor : BinaryOperations
{
    public Menor(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {
        Kind = NodeKind.Boolean;

    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())<Double.Parse(RightNode.Value.ToString());
        
    }
}

public class MenorIgual : BinaryOperations
{
    public MenorIgual(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {
        Kind = NodeKind.Boolean;

    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())<=Double.Parse(RightNode.Value.ToString());
    }
}