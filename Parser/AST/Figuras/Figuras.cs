using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BackEnd{
public abstract class Figura : Node
{
    public string Identifier { get; private set; }
    public NodeKind FigureKind { get; private set; }
    protected Figura( NodeKind kind, int actualLine) : base(kind, actualLine)
    {
        FigureKind = kind;
        
    }
protected Figura(string identifier,  NodeKind kind, int actualLine) : base(kind, actualLine)
    {
        Identifier = identifier;
        
    }
    public void SetIdentifier(string identifier)
    {
        Identifier = identifier;
    }
    public abstract void Draw();
}}