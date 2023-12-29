public class BasicExpression:Node
{
    public BasicExpression(object value, NodeKind kind, int actualLine):base(kind,actualLine)
    {
        SetValue(value);        
    }

    public override void Evaluate()
    {//NO hace nada porque aqui evaluate va a tener que llenar el value,
    //Y en una expresion basica el nodo se llena directamente en el constructor
    }
}
public class Constants:Node
{
    public string name{get; private set;}
    public Scope Scope{get; private set;}
    public Constants(string Name, Scope scope, int actualLine):base(NodeKind.Temp,actualLine)
    {//EL scope es para saber si existe y buscar su valor
        name = Name;
        Scope = scope;
    }

    public override void Evaluate()
    {
        Scope Search = Scope;
        bool existe = false;
        while(!(Search.father is null))
        {
            existe = Searching(Search);
        }
        if(!existe) existe = Searching(Search);
        //Porque él solo va a entrar al while si el padre es nulo, es decir si el scope no es el global
        //Pero si el scope es el global tambien habria que comprobar en él si la variable existe,
        // en caso de que no se haya encontrado ya

        if(!existe) throw new Exception("La variable "+name+ " no existe");
    }

    private bool Searching(Scope Search)
    {
        if(Search.constants.ContainsKey(name))
            {
                Node Copy = Search.constants[name];
                Copy.Evaluate();
                SetValue(Copy.Value);
                return true;
            }
            return false;
    }
}
public class Scope{
    public Scope father;
    public Dictionary<string,Node> constants{get; private set;}
    public Dictionary<string,Function> functions{get;private set;}
    public Scope(Scope Father){
        father = Father;
        constants = new Dictionary<string, Node>();
        functions = new Dictionary<string, Function>();
    }
    public void AddCOnstant(string name, Node Expresion)
    {
        constants.Add(name,Expresion);
    }
    public void AddFunction(string name, Function NewFunction)
    {
        functions.Add(name,NewFunction);
    }
}