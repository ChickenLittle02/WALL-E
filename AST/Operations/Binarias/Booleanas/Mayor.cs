public class Mayor : NumericasBinary
{
    public Mayor(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        bool result = Double.Parse(LeftNode.Value.ToString())>Double.Parse(RightNode.Value.ToString());
        SetValue(ForBoolean.BooleanValue(result));
    }
}

public class MayorIgual : NumericasBinary
{
    public MayorIgual(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        bool result = Double.Parse(LeftNode.Value.ToString())>=Double.Parse(RightNode.Value.ToString());
        SetValue(ForBoolean.BooleanValue(result));
    }
}