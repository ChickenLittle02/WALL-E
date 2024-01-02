public class Suma : NumericasBinary
{
    public Suma(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine)
    {
        
    }
    public override void Evaluate()
    {//Duda que pasa en el caso en que se recibe 4; por ejemplo
        LeftNode.Evaluate();
        RightNode.Evaluate();

        if(LeftNode.Value is double) SetValue(Double.Parse(LeftNode.Value.ToString())+Double.Parse(RightNode.Value.ToString()));
        else //RightNode.Value is Sequence
        {
        if(LeftNode.Value is InfiniteNumericSequence){
            if(RightNode.Value is UndefinedSequence) SetValue(new UndefinedSequence(ActualLine));
            else SetValue(LeftNode.Value);
            //Este es el caso de que sea una secuencia finita o una secuencia infinita
        }
        else if(LeftNode.Value is FiniteSequence)
        {
            
            if(RightNode.Value is UndefinedSequence) SetValue(new UndefinedSequence(ActualLine));
            else
            {
             //Para el caso de Finita + Infinita
             //{1,2,3,4} + {1 ...} = {1,2,3,4,1 ...}
             //El proceso sería mezclar las dos listas y poner como value una secuencia infinita con esa lista

             //Para el caso de Finita + Finita
             //{1,2,3,4} + {2,2,3,4} = {1,2,3,4,2,2,3,4}
             //El proceso sería mezclar las dos listas y poner como value una secuencia finita con esa lista
             
             List<Node> Left = ((Sequence)LeftNode.Value).SequenceValues;
             List<Node> Right = ((Sequence)RightNode.Value).SequenceValues;
             
             for(int i = 0; i<Right.Count;i++) Left.Add(Right[i]);

             if(RightNode.Value is InfiniteNumericSequence) SetValue(new InfiniteNumericSequence(Left,ActualLine));
             else SetValue(new FiniteSequence(Left,false,ActualLine));//No es generada (ejemplo{1,2,3 ... 4})
                //Para este else solo queda el caso de que el value sea un FiniteSequence

            }

        }else SetValue(new UndefinedSequence(ActualLine));
        //SOlo queda el caso de que la secuencia de la izquierda sea una secuencia Undefined, y en ese caso siempre va a ser Undefined
        }
    }
    public override void CheckSemantic()
    {
        LeftNode.CheckSemantic();
        RightNode.CheckSemantic();
        if(LeftNode.Kind is NodeKind.Number){
            if(RightNode.Kind is not NodeKind.Number&&RightNode.Kind is not NodeKind.Temp ) throw new Exception("No se puede usar el operador + con un tipo "+LeftNode.Kind+" "+RightNode.Kind);
            SetKind(NodeKind.Number);
        }
        else if(LeftNode.Kind is NodeKind.Sequence){
            if(RightNode.Kind is not NodeKind.Sequence&&RightNode.Kind is not NodeKind.Temp) throw new Exception("No se puede usar el operador + con un tipo "+LeftNode.Kind+" "+RightNode.Kind);
            SetKind(NodeKind.Sequence);
        }else if(LeftNode.Kind is NodeKind.Temp)
        {
        if(RightNode.Kind is NodeKind.Number) SetKind(NodeKind.Number);
        else if(RightNode.Kind is NodeKind.Sequence) SetKind(NodeKind.Sequence);
        else SetKind(NodeKind.Temp);    
        }else throw new Exception("No se puede usar el operador + con un tipo "+LeftNode.Kind+" "+RightNode.Kind);
        

    }//Recordar que en la suma tambien pueden haber secuencias
}

public class Resta : NumericasBinary
{
    public Resta(Node leftNode, Node rightNode,int actualLine) : base(leftNode, rightNode,actualLine){}
    public override void Evaluate()
    {
        LeftNode.Evaluate();
        RightNode.Evaluate();

        SetValue(Double.Parse(LeftNode.Value.ToString())-Double.Parse(RightNode.Value.ToString()));
        
    }
}