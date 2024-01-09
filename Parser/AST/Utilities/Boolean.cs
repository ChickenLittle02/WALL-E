namespace BackEnd{
public static class ForBoolean{
    public static double ToDoubleBooleanValue(bool value)
    {//Metodo para convertir a double un valor bool
        if(value) return (double)1;
        else return (double)0;
    }
    public static bool ConvertToBool(object value)
    {//Metodo para convertir a bool un objeto cualquiera en caso de ser posible
        if(value is Sequence)
        {
            Sequence Resultado = (Sequence)value;
            if(Resultado.IsUndefined) return false;
            else if(Resultado.Count==0) return false;
            else return true;
        }else if(!(value is double)) throw new Exception("Solo se pueden convertir a bool tipos numero y secuencias ");
        else
        {
            double Resultado = (double)value;
            if(Resultado==0) return false;
            else return true;
        }
    }

}

public static class ForFigura
{
    public static bool IsFigura(NodeKind Kind)
    {
            if ((Kind is NodeKind.Arco || Kind is NodeKind.Circunferencia)
            || (Kind is NodeKind.Line || Kind is NodeKind.Ray)
            || (Kind is NodeKind.Segment || Kind is NodeKind.Punto)) return true;
            else return false;
        
    }
}

}