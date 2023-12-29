public class Suma : NumericasBinary
{
    public Suma(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine)
    {
    }
    public override void Evaluate()
    {//Duda que pasa en el caso en que se recibe 4; por ejemplo
        LeftNode.Evaluate();
        RightNode.Evaluate();
        SetValue(Double.Parse(LeftNode.Value.ToString())+Double.Parse(RightNode.Value.ToString()));
    }
}

public class Resta : NumericasBinary
{
    public Resta(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();
        SetValue(Double.Parse(LeftNode.Value.ToString())-Double.Parse(RightNode.Value.ToString()));
        
    }
}