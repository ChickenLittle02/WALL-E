using System.Linq.Expressions;

public class Function
{
    public List<Node> Variables { get; private set; }
    public List<Token> TokensBody { get; private set; }
    public TokenType ReturnType { get; private set; }
    public Function(List<Node> variables, List<Token> tokensbody, TokenType returnType)
    {
        Variables = variables;
        TokensBody = tokensbody;
        ReturnType = returnType;
        //Aqui hay que chequear la sintaxis
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
