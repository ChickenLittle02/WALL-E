namespace BackEnd{
public abstract class Node
{

    public NodeKind Kind { get; private set; }
    public object Value
    {
        get;
        private set;
    }
    public int ActualLine { get; private set; }
    public void SetValue(object value) => Value = value;
    public void SetKind(NodeKind kind) => Kind = kind;
    public void Start(){
        CheckSemantic();
        Evaluate();
    }
    public Node(NodeKind kind, int actualLine)
    {
        Kind = kind;
        ActualLine = actualLine;
    }
    public abstract void Evaluate();
    public abstract void CheckSemantic();
    public override string ToString()
    {
        return Value.ToString();
    }

}

public enum NodeKind
{
    Color,
    Circunferencia,
    Number,
    Measure,
    String,
    Sequence,
    Figura,
    Punto,
    Line,
    Ray,
    Segment,
    Arco,
    Temp,
}}