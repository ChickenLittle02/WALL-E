namespace BackEnd
{
    public class PointFunction:Node{
        public Node X{get; private set;}
        public Node Y{get; private set;}
        
        public PointFunction(Node X_Value, Node Y_Value, int actualLine) : base(NodeKind.Punto, actualLine)
        {
            X = X_Value;
            Y = Y_Value;
        }
        public override void CheckSemantic()
        {
            X.CheckSemantic();
            if(X.Kind is not NodeKind.Number) throw new Exception("Se esperaba un tipo numerico");
            Y.CheckSemantic();            
            if(Y.Kind is not NodeKind.Number) throw new Exception("Se esperaba un tipo numerico");

        }

        public override void Evaluate()
        {
            X.Evaluate();
            Y.Evaluate();
            Node Value = new Punto(X,Y,ActualLine);
            Value.CheckSemantic();
            Value.Evaluate();
            SetValue(Value);
        }

}    
public class LineFunction:Node{
        public Node Point1{get; private set;}
        public Node Point2{get; private set;}
        
        public LineFunction(Node Point1, Node Point2, int actualLine) : base(NodeKind.Punto, actualLine)
        {
            this.Point1 = Point1;
            this.Point2 = Point2;
        }
        public override void CheckSemantic()
        {
            Point1.CheckSemantic();
            if(Point1.Kind is not NodeKind.Punto) throw new Exception("Se esperaba un tipo punto");
            Point2.CheckSemantic();            
            if(Point2.Kind is not NodeKind.Punto) throw new Exception("Se esperaba un tipo punto");

        }

        public override void Evaluate()
        {
            Point1.Evaluate();
            Point2.Evaluate();
            Node Value = new Line(Point1,Point2,ActualLine);
            Value.CheckSemantic();
            Value.Evaluate();
            SetValue(Value);
        }

}    
}