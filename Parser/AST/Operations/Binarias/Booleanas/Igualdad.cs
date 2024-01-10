namespace BackEnd{
public class Igual : NumericasBinary
{
    public Igual(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine,"=="){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        bool result = Double.Parse(LeftNode.Value.ToString())==Double.Parse(RightNode.Value.ToString());   
        SetValue(ForBoolean.ToDoubleBooleanValue(result));
    }
}

public class Distinto : NumericasBinary
{
    public Distinto(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine,"!="){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        bool result = Double.Parse(LeftNode.Value.ToString())!=Double.Parse(RightNode.Value.ToString());
        SetValue(ForBoolean.ToDoubleBooleanValue(result));
    }
}}