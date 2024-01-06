namespace BackEnd
{
    public abstract class SystemFunctionWithoutExpression : Node
    {//Es una funcion que devuelve una figura
        public SystemFunctionWithoutExpression(int actualLine) : base(NodeKind.Temp, actualLine)
        {
        }


    }
}