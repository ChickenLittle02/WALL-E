public class Function
{
    public List<string> Variables { get; private set; }
    public List<Token> TokensBody { get; private set; }
    public TokenType ReturnType { get; private set; }
    public Function(List<string> variables, List<Token> tokensbody, TokenType returnType)
    {
        Variables = variables;
        TokensBody = tokensbody;
        ReturnType = returnType;
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
