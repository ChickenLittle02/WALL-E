namespace BackEnd{
public class Count : SystemFunction
{
    public Count(Node Secuencia, int actualLine) : base(Secuencia, actualLine)
    {
        
    }
    public override void CheckSemantic()
    {
        Expression.CheckSemantic();
        if(Expression is not Sequence) throw new Exception("La funcion Count solo recibe una secuencia");
    }
    public override void Evaluate()
    {
        Expression.Evaluate();
        //Para este punto ya se que Expression es una secuencia, entonces lo que hago es devolver su count
        Sequence Secuencia = (Sequence)Expression;
        if(Secuencia is InfiniteNumericSequence) SetValue(new UndefinedSequence(ActualLine));
        else SetValue(Secuencia.Count);
    }

}}