public abstract class TernaryOperator : Node
{
    Node Principal;
    Node LeftNode;
    Node RightNode;

    public TernaryOperator(Node principal, Node leftNode, Node rightNode, int actualLine):base(rightNode.Kind,actualLine)
    {
        Principal=principal;
        LeftNode = leftNode;
        RightNode = rightNode;
    }

}