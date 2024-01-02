public abstract class BinaryOperations:Node{
    protected BinaryOperations(Node leftNode, Node rightNode, NodeKind kind, int actualLine):base(kind,actualLine)
    {
        LeftNode = leftNode;
        RightNode = rightNode;
    }
    public Node LeftNode;
    public Node RightNode;
    
}