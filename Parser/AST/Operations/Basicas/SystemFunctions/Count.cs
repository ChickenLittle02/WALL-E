namespace BackEnd{
public class Count : SystemFunction
{
    public Count(Node Secuencia, int actualLine) : base(Secuencia, actualLine)
    {
        
    }
    public override void CheckSemantic()
    {
        Expression.CheckSemantic();
        if(Expression.Kind is not NodeKind.Sequence&&Expression.Kind is not NodeKind.Temp ) new Error(ErrorKind.Semantic,$"Function Count recieve a sequence",ActualLine);
    }
    public override void Evaluate()
    {
        Expression.Evaluate();
        //Para este punto ya se que Expression es una secuencia, entonces lo que hago es devolver su count
        Sequence Secuencia = (Sequence)Expression.Value;
        if(Secuencia is InfiniteNumericSequence) SetValue(new UndefinedSequence(ActualLine));
        else SetValue(Secuencia.Count);
    }

}}