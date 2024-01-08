namespace BackEnd;
public abstract class Statement : Node
{
    protected Statement(NodeKind kind, int actualLine) : base(kind, actualLine)
    {
    }
}