namespace BackEnd{
public class IfElse : TernaryOperator
{
    public IfElse(Node principal, Node leftNode, Node rightNode, int actualLine) : base(principal, leftNode, rightNode, actualLine)
    {//Como ambos nodos deben de tener el mismo tipo, se asume que el tipo de cualquiera de los dos, es el tipo del nodo ifelse
     // if(leftNode.Kind!=rightNode.Kind) //Error ambos retornos de if-else deben ser del mismo tipo        


    }

    public override void Evaluate()
    {
        Principal.Evaluate();
        bool choise = ForBoolean.ConvertToBool(Principal.Value);
        if (choise)
        {
            LeftNode.Evaluate();
            SetValue(LeftNode.Value);
        }
        else
        {
            RightNode.Evaluate();
            SetValue(RightNode.Value);
        }
    }
    public override void CheckSemantic()
    {
        Principal.CheckSemantic();
        LeftNode.CheckSemantic();
        RightNode.CheckSemantic();
        if (LeftNode.Kind != RightNode.Kind&&LeftNode.Kind is not NodeKind.Temp&&RightNode.Kind is not NodeKind.Temp) 
        new Error(ErrorKind.Semantic,$"If else expression can't return diferents kinds:{RightNode.Kind} and {LeftNode.Kind}",ActualLine);
         
    }



}}