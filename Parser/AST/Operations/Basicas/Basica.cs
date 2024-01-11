namespace BackEnd{
public class BasicExpression : Node
{
    public BasicExpression(object value, NodeKind kind, int actualLine) : base(kind, actualLine)
    {
        SetValue(value);
    }

    public override void Evaluate()
    {//NO hace nada porque aqui evaluate va a tener que llenar el value,
     //Y en una expresion basica el nodo se llena directamente en el constructor
    }

    public override void CheckSemantic()
    {
    }
}
public class Constants : Node
{
    public string name { get; private set; }
    public Scope Scope { get; private set; }
    public Constants(string Name, Scope scope, int actualLine) : base(NodeKind.Temp, actualLine)
    {//EL scope es para saber si existe y buscar su valor
        name = Name;
        Scope = scope;
    }

    public override void Evaluate()
    {//Habria que buscar si la constante existe en algun scope
        Scope Search = Scope;
        bool existe = false;
        while (!(Search.father is null))
        {
            existe = Searching(Search, false);
            if (existe) break;
            Search = Search.father;
        }
        if (!existe) existe = Searching(Search, false);
        
    }


    public override void CheckSemantic()
    {//Habria que buscar si la constante existe en algun scope
        Scope Search = Scope;
        bool existe = false;
        while (!(Search.father is null))
        {
            existe = Searching(Search, true);
            if (existe) break;
            else Search = Search.father;
        }
        if (!existe) existe = Searching(Search, true);
        //Porque él solo va a entrar al while si el padre es nulo, es decir si el scope no es el global
        //Pero si el scope es el global tambien habria que comprobar en él si la variable existe,
        // en caso de que no se haya encontrado ya

        if (!existe) new Error(ErrorKind.Semantic,"La constante " + name + " no existe",ActualLine);
    }
    private bool Searching(Scope Search, bool IsSemantic)
    {
        if (Search.constants.ContainsKey(name))
        {
            if (IsSemantic)
            {
                if(Search.constants[name] is null) SetKind(NodeKind.Temp);
                else{
                Search.constants[name].CheckSemantic();
                SetKind(Search.constants[name].Kind);}
                return true;
            }
            else
            {
                Search.constants[name].Evaluate();
                SetValue(Search.constants[name].Value);
                SetKind(Search.constants[name].Kind);
                return true;

            }
        }
        return false;
    }
}
public class Scope
{
    public Scope father;
    public Dictionary<string, Node> constants { get; private set; }
    public Dictionary<string, Function> functions { get; private set; }
    public Scope(Scope Father)
    {
        father = Father;
        constants = new Dictionary<string, Node>();
        functions = new Dictionary<string, Function>();
    }
    public void AddCOnstant(string name, Node Expresion)
    {
        constants.Add(name, Expresion);
    }
    public void AddFunction(string name, Function NewFunction)
    {
        functions.Add(name, NewFunction);
    }
    public void RemoveFUnction(string name)
    {
        functions.Remove(name);
    }
}
}