public class Resto : BinaryOperations
{
    public Resto(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {

    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())%Double.Parse(RightNode.Value.ToString());
        Kind = NodeKind.Number;
    
        
    }
}

public class Potencia : BinaryOperations
{
    public Potencia(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {

        Kind = NodeKind.Number;
    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Math.Pow(Double.Parse(LeftNode.Value.ToString()),Double.Parse(RightNode.Value.ToString()));
        
    }
}