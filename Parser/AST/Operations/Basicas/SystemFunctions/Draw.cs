namespace BackEnd
{
    public class Draw : SystemFunction
    {
        public string ID { get; private set; }
        public Draw(string id, Node Figura, int actualLine) : base(Figura, actualLine)
        {
            ID = id;
        }
        public override void CheckSemantic()
        {
            Expression.CheckSemantic();
            if (!ForFigura.IsFigura(Expression.Kind) && Expression.Kind is not NodeKind.Sequence) throw new Exception("La funcion Draw solo recibe figuras o secuencias de figuras");
        }

        public override void Evaluate()
        {
            Expression.Evaluate();
            //Para este punto ya se que Value de Expression es una figura o una secuencia
            if (Expression.Value is Figura)
            {
                Figura ToDraw = (Figura)Expression.Value;
                ToDraw.CheckSemantic();
                ToDraw.Evaluate();
                ToDraw.Draw();
            }
            else if (Expression.Value is Sequence)
            {
                Sequence SequenceExpression = (Sequence)Expression.Value;
                SequenceExpression.CheckSemantic();
                SequenceExpression.Evaluate();
                if (!ForFigura.IsFigura(SequenceExpression.SequenceDataKind))
                {

                    if (SequenceExpression.SequenceDataKind is not NodeKind.Sequence)
                        throw new Exception("La secuencia recibida por la funcion draw debe ser de figuras o secuencias de figuras");

                }
                else
                {
                    List<Node> Figuras = SequenceExpression.BuildList(0);
                    if (Figuras.Count == 0)
                        throw new Exception("La secuencia recibida por la funcion draw debe ser de figuras o secuencias de figuras");
                    else for (int i = 0; i < Figuras.Count; i++)
                        {
                            Draw DIbuja = new Draw(ID, Figuras[i], ActualLine);
                            DIbuja.CheckSemantic();
                            DIbuja.Evaluate();
                        }

                }

            }
        }

    }
}