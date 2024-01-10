namespace BackEnd{
public abstract class NumericasBinary:BinaryOperations
{
    public NumericasBinary(Node leftNode, Node rightNode, int actualLine, string Operator):base(leftNode,rightNode,NodeKind.Number,actualLine){
        this.Operator = Operator;
    }
    
    public string Operator{get; protected set;}
    public override void CheckSemantic()
    {//De esta manera se está asumiendo que todas las operaciones son matematicas
        LeftNode.CheckSemantic();
        RightNode.CheckSemantic();
        if(!(LeftNode.Kind is NodeKind.Number)&&!(RightNode.Kind is NodeKind.Number||RightNode.Kind is NodeKind.Temp)) 
        new Error(ErrorKind.Semantic,$"You can't use {Operator} operator with "+LeftNode.Kind+" "+RightNode.Kind,ActualLine);

    }
}}