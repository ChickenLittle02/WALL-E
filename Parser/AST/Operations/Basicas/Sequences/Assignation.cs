using System.Reflection.Metadata;
namespace BackEnd
{
    public class AssignationSequences : Node
    {
        public int ConstantPosition { get; private set; }
        public bool EsUltimo { get; private set; }
        public Sequence Secuencia { get; private set; }
        public Node Expression { get; set; }
        public object Value { get; set; }
        public AssignationSequences(int ConstantPosition, bool EsUltimo, Node Secuencia, int actualLine) : base(NodeKind.Temp, actualLine)
        {
            this.ConstantPosition = ConstantPosition;
            this.EsUltimo = EsUltimo;
            Expression = Secuencia;
CheckSemantic();
        }

        public override void CheckSemantic()
        {
            Expression.CheckSemantic();
            SetKind(NodeKind.Temp);
            if(Expression.Kind is not NodeKind.Sequence && Expression.Kind is not NodeKind.Temp) new Error(ErrorKind.Semantic,$"Expression associated must be a sequence not {Expression.Kind}",ActualLine);
            //Hay que revisar si la variable existia o no en algun scope, ya sea el actual o el anterior
        }

        public override void Evaluate()
        {
            Expression.Evaluate();
            Secuencia = (Sequence)Expression.Value;
            Secuencia.Start();
            if (Secuencia is FiniteSequence)
            {
                if (ConstantPosition < Secuencia.Count)
                {
                    if (EsUltimo) SetValue(new FiniteSequence(Secuencia.BuildList(ConstantPosition), false, ActualLine));
                    else {
                        SetValue(Secuencia.SequenceValues[ConstantPosition].Value);
                        SetKind(NodeKind.Number);
                        }
                }
                else if (ConstantPosition > Secuencia.Count)
                {
                    if (EsUltimo) SetValue(new FiniteSequence(new List<Node>(), false, ActualLine));//Secuencia vacia
                    else SetValue(new UndefinedSequence(ActualLine));
                }
                else
                {
                    //COnstantPosition==Secuencia.COunt
                    //a,b = {}, b = {}, 
                    if (EsUltimo) SetValue(new FiniteSequence(new List<Node>(), false, ActualLine));//Secuencia vacia
                    else SetValue(new UndefinedSequence(ActualLine));
                    //{a,b} = {}, a = Undefined

                }
            }

            else if (Secuencia is InfiniteNumericSequence)
            {
                if (ConstantPosition < Secuencia.Count)
                {
                    if (EsUltimo) SetValue(new InfiniteNumericSequence(Secuencia.BuildList(ConstantPosition), ActualLine));
                    else 
                    {SetValue(Secuencia.SequenceValues[ConstantPosition].Value);
                    SetKind(NodeKind.Number);}
                }
                else
                {
                    // ConstantPosition>=Secuencia.Count

                    double FirstValue = double.Parse(Secuencia.SequenceValues[Secuencia.Count - 1].ToString()) + ConstantPosition - Secuencia.Count + 1;
                    if (EsUltimo)
                    {
                        List<Node> NewSequenceElements = new List<Node>();
                        //Comprobar si esto da error en que linea lo doy
                        NewSequenceElements.Add(new BasicExpression(FirstValue, NodeKind.Number, ActualLine));
                        SetValue(new InfiniteNumericSequence(NewSequenceElements, ActualLine));
                    }
                    else
                    {
                        SetValue(FirstValue);
                        SetKind(NodeKind.Number);
                    }
                }
            }
            else SetValue(new UndefinedSequence(ActualLine));
            //Este caso es en el que la secuencia es Undefined

        }
    }
}