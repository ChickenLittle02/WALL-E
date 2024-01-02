public abstract class NumericasBinary:BinaryOperations
{
    public NumericasBinary(Node leftNode, Node rightNode, int actualLine):base(leftNode,rightNode,NodeKind.Number,actualLine){
        CheckSemantic();
    }
    public override void CheckSemantic()
    {//De esta manera se está asumiendo que todas las operaciones son matematicas
        LeftNode.CheckSemantic();
        if(!(LeftNode.Kind is NodeKind.Number)) throw new Exception("Debe ser de tipo number");
        RightNode.CheckSemantic();
        if(!(RightNode.Kind is NodeKind.Number)) throw new Exception("Debe ser de tipo number");

    }
}