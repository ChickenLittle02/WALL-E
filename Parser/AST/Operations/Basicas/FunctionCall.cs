namespace BackEnd{
public class FunctionCall : Node
{
    public Scope ScopeForSearchFunction { get; private set; }
    public string Name { get; private set; }
    public List<Node> Argumentos { get; private set; }
    public List<Token> BodyTokens { get; private set; }
    public List<Node> Constantes { get; private set; }
    public Scope ScopeForBody { get; private set; }
    public Node FunctionExpression { get; private set; }

    public FunctionCall(string name, List<Node> RecieveExpression, Scope ScopeForSearchFunction, int actualLine) : base(NodeKind.Temp, actualLine)
    {
        Name = name;
        this.ScopeForSearchFunction = ScopeForSearchFunction;
        Argumentos = RecieveExpression;
    }
    public override void CheckSemantic()
    {//Habria que buscar si la funcion existe en algun scope
        Scope Search = ScopeForSearchFunction;
        bool existe = false;
        while (!(Search.father is null))
        {
            existe = Searching(Search);
            if (existe) break;
            Search = Search.father;
        }
        if (!existe) existe = Searching(Search);
        //Porque él solo va a entrar al while si el padre es nulo, es decir si el scope no es el global
        //Pero si el scope es el global tambien habria que comprobar en él si la variable existe,
        // en caso de que no se haya encontrado ya

        if (!existe) new Error(ErrorKind.Semantic,"Function " + Name + " doesn't exist",ActualLine);
    }

    public override void Evaluate()
    {
        var ANalizeExpressionFunction = new Syntax_Analizer.Syntax(BodyTokens, ScopeForBody);
        ANalizeExpressionFunction.Start();
        FunctionExpression = ANalizeExpressionFunction.NodesLines[0];
        FunctionExpression.CheckSemantic();
        FunctionExpression.Evaluate();
        SetValue(FunctionExpression.Value);
    }

    private bool Searching(Scope Search)
    {
        if (Search.functions.ContainsKey(Name))
        {
            if (Search.functions[Name].Argumentos.Count != Argumentos.Count)
            new Error(ErrorKind.Semantic,"La funcion " + Name + " debe recibir " + Argumentos.Count + " argumentos",ActualLine);
            ScopeForBody = new Scope(Search.functions[Name].ScopeForBody);
            BodyTokens = Search.functions[Name].TokensBody;

            for (int i = 0; i < Argumentos.Count; i++) ScopeForBody.AddCOnstant(Search.functions[Name].Argumentos[i], Argumentos[i]);
            // Agrega las constantes al scope para procesar la funcion
            //Crear nueva instancia de parser para parsear el body
            return true;

        }
        return false;
    }
}}