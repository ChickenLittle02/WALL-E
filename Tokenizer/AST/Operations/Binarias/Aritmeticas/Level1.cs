public class Suma : BinaryOperations
{
    public Suma(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {
        Kind = NodeKind.Number;

    }
    public override void Evaluate()
    {//Duda que pasa en el caso en que se recibe 4; por ejemplo
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())+Double.Parse(RightNode.Value.ToString());
    }
}

public class Resta : BinaryOperations
{
    public Resta(Node leftNode, Node rightNode) : base(leftNode, rightNode)
    {
        

    }
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        Value = Double.Parse(LeftNode.Value.ToString())-Double.Parse(RightNode.Value.ToString());
        Kind = NodeKind.Number;
        
    }
}