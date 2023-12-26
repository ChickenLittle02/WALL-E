public class BasicExpression:Node
{
    public BasicExpression(Token value)
    {
        if(value.Type is TokenType.BreakLine)Kind = NodeKind.BreakLine;
        else if(value.Type is TokenType.Number) Kind = NodeKind.Number;
        else Kind = NodeKind.String; 
        //value is string

        Value = value.Value;        
    }

    public override void Evaluate()
    {//NO hace nada porque aqui evaluate va a tener que llenar el value,
    //Y en una expresion basica el nodo se llena directamente en el constructor
    }
}