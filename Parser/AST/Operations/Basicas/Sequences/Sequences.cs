namespace BackEnd{
public abstract class Sequence : Node
{
    public int Count { get; private set; }
    public bool IsUndefined { get; private set; }
    public List<Node> SequenceValues { get; private set; }
    public List<Node> GetELements => SequenceValues;
    public NodeKind SequenceDataKind { get; protected set; }
    public Sequence(List<Node> values, int actualLine) : base(NodeKind.Sequence, actualLine)
    {
        SetValue(values);
        SequenceValues = values;
        Count = values.Count;
    }

    public void SetIsUndefined(){ IsUndefined = true; }
    public void ActualizaCount() { Count = SequenceValues.Count; }
    public List<Node> BuildList(int StartPosition)
    {   
        if(StartPosition == Count && Count == 0) return new List<Node>();

        if(StartPosition>=Count) new Error(ErrorKind.Semantic,$"Isn't possible make a sequence in {StartPosition} if this sequence have a size of {Count}",ActualLine);
        else{        
        List<Node> NuevaLista = new List<Node>(Count - StartPosition);
        for(int i = StartPosition; i<Count;i++) NuevaLista.Add(SequenceValues[i]);
        return NuevaLista;
        }
        return new List<Node>();   
        }
}}