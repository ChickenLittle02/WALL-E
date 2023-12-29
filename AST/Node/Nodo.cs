

public abstract class Node
{
    
    public NodeKind Kind{get; private set;}
    public object Value { get; private set; }
    public int ActualLine{ get; private set;}
    public void SetValue(object value) => Value = value;
    public Node(NodeKind kind, int actualLine)
    {
        Kind = kind;
        ActualLine = actualLine;
    }
    public abstract void Evaluate();

}

public enum NodeKind
{
    Number,
    String,
    Temp,
}