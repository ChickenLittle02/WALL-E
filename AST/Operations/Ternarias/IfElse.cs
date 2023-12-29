public class IfElse : TernaryOperator
{
    public IfElse(Node principal, Node leftNode, Node rightNode, int actualLine) : base(principal, leftNode, rightNode, actualLine)
    {//Como ambos nodos deben de tener el mismo tipo, se asume que el tipo de cualquiera de los dos, es el tipo del nodo ifelse
        // if(leftNode.Kind!=rightNode.Kind) //Error ambos retornos de if-else deben ser del mismo tipo        
    }

    public override void Evaluate()
    {
        //if() principal is true LeftNode.Evaluate; return LeftNode.Value;
        //else es porque principal is false RightNode.Evaluate; return RightNode.Value;
        throw new NotImplementedException();
    }
}