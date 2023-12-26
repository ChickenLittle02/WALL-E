public class IfElse : TernaryOperator
{
    public IfElse(Node principal, Node leftNode, Node rightNode) : base(principal, leftNode, rightNode)
    {
        // if(leftNode.Kind!=rightNode.Kind) //Error ambos retornos de if-else deben ser del mismo tipo        
    }

    public override void Evaluate()
    {
        //if() principal is true LeftNode.Evaluate; return LeftNode.Value;
        //else es porque principal is false RightNode.Evaluate; return RightNode.Value;
        throw new NotImplementedException();
    }
}