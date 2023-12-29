public class Menor : NumericasBinary
{
    public Menor(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        bool result = Double.Parse(LeftNode.Value.ToString())<Double.Parse(RightNode.Value.ToString());
        SetValue(ForBoolean.BooleanValue(result));
    }
}

public class MenorIgual : NumericasBinary
{
    public MenorIgual(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        bool result = Double.Parse(LeftNode.Value.ToString())<=Double.Parse(RightNode.Value.ToString());
        SetValue(ForBoolean.BooleanValue(result));
    }
}