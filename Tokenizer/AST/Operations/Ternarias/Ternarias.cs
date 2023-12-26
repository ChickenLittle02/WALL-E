public abstract class TernaryOperator : Node
{
    Node Principal;
    Node LeftNode;
    Node RightNode;

    public TernaryOperator(Node principal, Node leftNode, Node rightNode)
    {
        Principal=principal;
        LeftNode = leftNode;
        RightNode = rightNode;
    }

}