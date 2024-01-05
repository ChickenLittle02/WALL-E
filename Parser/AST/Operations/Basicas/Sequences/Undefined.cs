namespace BackEnd{
public class UndefinedSequence : Sequence
{
    public UndefinedSequence(int actualLine) : base(new List<Node>(), actualLine)
    {
        SetIsUndefined();
    }
    public override string ToString()
    {
        return "UNDEFINED";
    }
    public override void CheckSemantic()
    {
    }

    public override void Evaluate()
    {
    }
}}