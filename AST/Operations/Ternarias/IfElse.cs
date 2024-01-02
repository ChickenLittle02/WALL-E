using System.Security.Principal;

public class IfElse : TernaryOperator
{
    public IfElse(Node principal, Node leftNode, Node rightNode, int actualLine) : base(principal, leftNode, rightNode, actualLine)
    {//Como ambos nodos deben de tener el mismo tipo, se asume que el tipo de cualquiera de los dos, es el tipo del nodo ifelse
        // if(leftNode.Kind!=rightNode.Kind) //Error ambos retornos de if-else deben ser del mismo tipo        
        CheckSemantic();
        
    }

    public override void Evaluate()
    {
        Principal.Evaluate();
        bool choise = ForBoolean.ConvertToBool(Principal.Value);
        LeftNode.Evaluate();
        RightNode.Evaluate();
        if(choise) SetValue(LeftNode.Value);
        else SetValue(RightNode.Value);
    }
    public override void CheckSemantic()
    {
        Principal.CheckSemantic();
        LeftNode.CheckSemantic();
        RightNode.CheckSemantic();
        if(LeftNode.Kind != RightNode.Kind) throw new Exception("Ambos retornos deben ser del mismo tipo");
    }



}