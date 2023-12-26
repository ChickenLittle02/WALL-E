

public abstract class Node
{
    public NodeKind Kind{get; set;}
    public object Value { get; set; }
    public abstract void Evaluate();

    // public abstract object Value{get; set;}
    // public abstract void Evaluate();//Este va a ser un metodo que 

}

public enum NodeKind
{
    Number,
    String,
    Boolean,
    BreakLine,
}