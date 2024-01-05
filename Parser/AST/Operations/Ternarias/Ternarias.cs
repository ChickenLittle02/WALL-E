namespace BackEnd{
public abstract class TernaryOperator : Node
{
    protected Node Principal;
    protected Node LeftNode;
    protected Node RightNode;

    public TernaryOperator(Node principal, Node leftNode, Node rightNode, int actualLine):base(rightNode.Kind,actualLine)
    {
        Principal=principal;
        LeftNode = leftNode;
        RightNode = rightNode;
    }

}}