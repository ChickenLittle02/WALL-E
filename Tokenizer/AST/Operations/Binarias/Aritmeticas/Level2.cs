public class Multiplicacion : BinaryOperations
{
    public Multiplicacion(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {
                Kind = NodeKind.Number;
    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())*Double.Parse(RightNode.Value.ToString());;
    }
}

public class Division : BinaryOperations
{
    public Division(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {
                Kind = NodeKind.Number;
    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())/Double.Parse(RightNode.Value.ToString());;       
    }
}