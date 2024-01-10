namespace BackEnd{
public class FiniteSequence : Sequence
{
    private bool EsGenerada { get; set; }
    public FiniteSequence(List<Node> values, bool esGenerada, int actualLine) : base(values, actualLine)
    {
        EsGenerada = esGenerada;
        CheckSemantic();
    }
    public override string ToString()
    {
        if(Count==0) return"{}";
        string result = "";
        for (int i = 0; i < Count; i++)
        {
            if (i == 0) result += SequenceValues[i];
            else result += "," + SequenceValues[i];
        }

        return result;
    }

    public override void Evaluate()
    {
        for (int i = 0; i < Count; i++)
        {
            SequenceValues[i].Evaluate();
        }
        SetValue(this);
    }

    public override void CheckSemantic()
    {

        if (Count != 0)
        {
            SequenceValues[0].CheckSemantic();
            SequenceDataKind = SequenceValues[0].Kind;


            for (int i = 1; i < Count; i++)
            {
                SequenceValues[i].CheckSemantic();
                if (SequenceDataKind != SequenceValues[i].Kind) new Error(ErrorKind.Semantic,"All sequence expressions must be equal",ActualLine);
            }

            if (EsGenerada)
            {//Tengo que generar todos los valores que necesite
                SequenceDataKind = NodeKind.Number;
                SequenceValues[Count - 2].Evaluate();
                double LowerBound = Double.Parse(SequenceValues[Count - 2].ToString());
                if (LowerBound % 1 != 0) new Error(ErrorKind.Semantic,$"Expression limits must be int not {LowerBound}",ActualLine);


                SequenceValues[Count - 1].Evaluate();
                double UpperBound = Double.Parse(SequenceValues[Count - 1].ToString());
                if (UpperBound % 1 != 0) new Error(ErrorKind.Semantic,$"Expression limits must be int not {UpperBound}",ActualLine);
                if (LowerBound > UpperBound) new Error(ErrorKind.Semantic,$"Upper bound {UpperBound} must be greater than {LowerBound}",ActualLine);
                SequenceValues.RemoveAt(Count - 1);
                double temp = LowerBound + 1;

                for (double i = temp; i <= UpperBound; i++)
                {
                    SequenceValues.Add(new BasicExpression(i, NodeKind.Number, ActualLine));
                    //Este actualLine es el de donde hago la secuencia
                }
                SetValue(SequenceValues);
                ActualizaCount();
                ToString();

            }
        }
    }

}
public class InfiniteNumericSequence : Sequence
{
    public InfiniteNumericSequence(List<Node> values, int actualLine) : base(values, actualLine)
    {
        CheckSemantic();
    }
    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < Count; i++)
        { if(i==0)  result += SequenceValues[i];
        else    result += ","+SequenceValues[i];
        }
        result += " ...";

        return result;
    }

    public override void CheckSemantic()
    {
        if (Count != 0)
        {
            SequenceValues[0].CheckSemantic();
            SequenceDataKind = SequenceValues[0].Kind;


            for (int i = 1; i < Count; i++)
            {
                SequenceValues[i].CheckSemantic();
                if (SequenceDataKind != SequenceValues[i].Kind) throw new Exception("All sequence data must beequal");
            }
        }
    }

    public override void Evaluate()
    {
        for (int i = 0; i < Count; i++)
        {
            SequenceValues[i].Evaluate();
        }
        SetValue(this);
    }
}}