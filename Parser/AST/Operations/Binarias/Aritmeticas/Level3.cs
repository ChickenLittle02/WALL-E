namespace BackEnd{
public class Resto : NumericasBinary
{
    public Resto(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}

    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        SetValue(Double.Parse(LeftNode.Value.ToString())%Double.Parse(RightNode.Value.ToString()));        
    }
}

public class Potencia : NumericasBinary
{
    public Potencia(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        SetValue(Math.Pow(Double.Parse(LeftNode.Value.ToString()),Double.Parse(RightNode.Value.ToString())));
        
    }
}}