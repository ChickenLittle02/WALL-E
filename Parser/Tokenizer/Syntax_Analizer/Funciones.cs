namespace BackEnd{
public class Function
{
    public List<Node> Variables { get; private set; }
    public List<Token> TokensBody { get; private set; }
    public TokenType ReturnType { get; private set; }
    public List<string> Argumentos { get; private set; }
    public string Name{ get; private set; }
    
    public Scope ScopeForBody { get; private set; }
    public Function(string name, List<Node> variables, List<Token> tokensbody, TokenType returnType, Scope ScopeForBody)
    {
        Variables = variables;
        TokensBody = tokensbody;
        ReturnType = returnType;
        Argumentos = new List<string>();
        this.ScopeForBody = ScopeForBody;
        Name = name;
        CheckSemantic();
        foreach (Constants item in Variables)   Argumentos.Add(item.name);
        

    }
    public Function(string name)
    {}
    public void CheckSemantic()
    {
        //Buscar si la funcion existe en este scope, para no sobreescribirla
        if(ScopeForBody.functions.ContainsKey(Name)) throw new Exception("No se puede sobreescribir la funcion");
        var Lista = Variables.Where(x => x is not Constants);
        if (Lista.Count() is not 0) throw new Exception("Los parametros que recibe la funcion deben ser constantes");
        
        //Mostrar al menos un elemento de los que no son constantes

    }

    public void CHangeBody(List<Token> tokensBody)
    {
        TokensBody = tokensBody;
    }

    public void ShowVariables()
    {

        System.Console.WriteLine("Variables");
        System.Console.WriteLine(" ");
        foreach (var item in this.Variables)
        {
            System.Console.WriteLine(item);
        }
    }

    public void ShowBody()
    {
        System.Console.WriteLine("Body");
        System.Console.WriteLine(" " + this.TokensBody.Count);
        foreach (var item in this.TokensBody)
        {
            item.Show();
        }
    }
}
}