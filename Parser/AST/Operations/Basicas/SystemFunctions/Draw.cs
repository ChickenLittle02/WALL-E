namespace BackEnd{
public class Draw : SystemFunction
{
    public Draw(Node Figura, int actualLine) : base(Figura, actualLine)
    {
        
    }
    public override void CheckSemantic()
    {
        Expression.CheckSemantic();
        if(!IsFigura() && Expression.Kind is not NodeKind.Sequence) throw new Exception("La funcion Draw solo recibe figuras o secuencias de figuras");
    }

    private bool IsFigura(){
        if((Expression.Kind is NodeKind.Arco || Expression.Kind is NodeKind.Circunferencia)
        || (Expression.Kind is NodeKind.Line||Expression.Kind is NodeKind.Ray)
        ||(Expression.Kind is NodeKind.Segment||Expression.Kind is NodeKind.Punto)) return true;
        else return false;
    }

    public override void Evaluate()
    {
        Expression.Evaluate();
        //Para este punto ya se que Value de Expression es una figura o una secuencia
        if(Expression.Value is Figura)
        {
            Figura ToDraw = (Figura)Expression.Value;
            ToDraw.CheckSemantic();
            ToDraw.Evaluate();
            ToDraw.Draw();
        }else if(Expression.Value is Sequence)
        {
            throw new NotImplementedException();
        }
    }

}}