namespace BackEnd{
public class RandomSequence : Node
{
    public RandomSequence(int actualLine) : base(NodeKind.Number, actualLine)
    {

    }

    public override void CheckSemantic()
    {
    }

    public override void Evaluate()
    {
        List<Node> NumberSet = new List<Node>();
        Random RandomNumber = new Random();
        for(int i = 0; i<20; i++)
        {
            BasicExpression ActualNumber = new BasicExpression(RandomNumber.NextDouble(),NodeKind.Number,ActualLine);
            NumberSet.Add(ActualNumber);
            
        }
        Sequence Secuencia = new FiniteSequence(NumberSet,false,ActualLine);
        Secuencia.CheckSemantic();
        Secuencia.Evaluate();
        SetValue(Secuencia);
        
    }
}}