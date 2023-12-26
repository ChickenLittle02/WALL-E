public abstract class BinaryOperations:Node{
    protected BinaryOperations(Node leftNode, Node rightNode)
    {
        LeftNode = leftNode;
        RightNode = rightNode;
    }
    public Node LeftNode;
    public Node RightNode;

    
}