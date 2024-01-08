using System.Linq.Expressions;


namespace BackEnd;
public class IntersectionFunction : Node
{
    public Node Figura1 { get; private set; }
    public Node Figura2 { get; private set; }
    public IntersectionFunction(Node figura1, Node figura2, int actualLine) : base(NodeKind.Sequence, actualLine)
    {
        Figura1 = figura1;
        Figura2 = figura2;
    }

    public override void CheckSemantic()
    {
        Figura1.CheckSemantic();
        if (!IsFigura(Figura1)) throw new Exception("Se esperaba una figura");
        Figura2.CheckSemantic();
        if (!IsFigura(Figura2)) throw new Exception("Se esperaba una figura");
    }
    private bool IsFigura(Node Expression)
    {
        if ((Expression.Kind is NodeKind.Arco || Expression.Kind is NodeKind.Circunferencia)
        || (Expression.Kind is NodeKind.Line || Expression.Kind is NodeKind.Ray)
        || (Expression.Kind is NodeKind.Segment || Expression.Kind is NodeKind.Punto)) return true;
        else return false;
    }
    public override void Evaluate()
    {
        Figura1.Evaluate();
        Figura2.Evaluate();
        Sequence Resultado = Intersection.IntersectionFigure(Figura1,Figura2, ActualLine);        
    }
}