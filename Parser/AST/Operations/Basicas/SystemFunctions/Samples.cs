// namespace BackEnd{
// public class Sample : Node
// {
//     public Sample(int actualLine) : base(NodeKind.Sequence, actualLine)
//     {
//         //Esta funcion no recibe nada
//     }

//     public override void CheckSemantic()
//     {
//     }

//     public override void Evaluate()
//     {
//         List<Node> PointsSet = new List<Node>();
//         for(int i = 0; i<20; i++)
//         {
//             Punto ActualPunto = new Punto(ActualLine);
//             ActualPunto.CheckSemantic();
//             ActualPunto.Evaluate();
//             PointsSet.Add(ActualPunto);
            
//         }
//         Sequence Secuencia = new FiniteSequence(PointsSet,false,ActualLine);
//         Secuencia.CheckSemantic();
//         Secuencia.Evaluate();
//         SetValue(Secuencia);
        
//     }
// }}
