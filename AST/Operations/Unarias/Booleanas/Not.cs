using System.Linq.Expressions;

public class Not : UnaryOperator
{
    public Not(Node expression, int actualLine) : base(expression, actualLine){
        CheckSemantic();
    }

    public override void Evaluate()
    {
        Expression.Evaluate();

        SetValue(!(bool)Expression.Value);
    }//Revisar aplicacion de operadores booleanos
    public override void CheckSemantic()
    {//Recordar que hay que implementar
        throw new NotImplementedException();
    }
}