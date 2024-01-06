using System.Runtime.CompilerServices;
using Microsoft.JSInterop;

namespace  BackEnd
{
public class ForDraw
{
    public static IJSRuntime _jsRuntime;
    public static void SetRuntime(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
}
    
}