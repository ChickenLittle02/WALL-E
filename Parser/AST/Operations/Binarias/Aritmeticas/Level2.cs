namespace BackEnd{
public class Multiplicacion : NumericasBinary
{
    public Multiplicacion(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        SetValue(Double.Parse(LeftNode.Value.ToString())*Double.Parse(RightNode.Value.ToString()));
    }
}

public class Division : NumericasBinary
{
    public Division(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}
    
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        SetValue(Double.Parse(LeftNode.Value.ToString())/Double.Parse(RightNode.Value.ToString()));       
    }
}}