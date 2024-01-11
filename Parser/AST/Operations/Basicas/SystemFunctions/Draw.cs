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
            if (!ForFigura.IsFigura(Expression.Kind) && Expression.Kind is not NodeKind.Sequence && Expression.Kind is not NodeKind.Temp) 
            new Error(ErrorKind.Semantic,$"Function Draw only recieve figures or sequences",ActualLine);
        
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
                ToDraw.Draw(ID);
            }
            else if (Expression.Value is Sequence)
            {
                Sequence SequenceExpression = (Sequence)Expression.Value;
                SequenceExpression.CheckSemantic();
                SequenceExpression.Evaluate();
                List<Node> Figuras = SequenceExpression.BuildList(0);
                if (Figuras.Count != 0)
                {

                    if (!ForFigura.IsFigura(SequenceExpression.SequenceDataKind))
                    {

                        if (SequenceExpression.SequenceDataKind is not NodeKind.Sequence)
                        new Error(ErrorKind.Semantic,$"Unexpected type {SequenceExpression.SequenceDataKind}: Recieved sequence for the Function Draw must be only recieve figures or figures sequences",ActualLine);
        

                    }
                    else
                    {
                        if (Figuras.Count != 0)
                            for (int i = 0; i < Figuras.Count; i++)
                            {
                                Draw DIbuja = new Draw(ID, Figuras[i], ActualLine);
                                DIbuja.CheckSemantic();
                                DIbuja.Evaluate();
                            }

                    }
                }

            }
            else new Error(ErrorKind.Semantic,$"Unexpected type {Expression.Kind}: Recieved sequence for the Function Draw must be only recieve figures or figures sequences",ActualLine);
 
        }




    }
}