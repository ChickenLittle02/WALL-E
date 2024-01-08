using Microsoft.JSInterop;
using System.Threading.Tasks;
namespace BackEnd;
public class Bib1Interop
{
    public static IJSRuntime _jsRuntime;

    public static void InyectandoRuntime(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }


}

public class Drawing
{
    public static async Task DibujarEnCanvas()
    {
        // Llamar a la función JavaScript desde C# usando IJSRuntime
        await Bib1Interop._jsRuntime.InvokeAsync<object>("canvasInterop.dibujarEnCanvas");
    }
}
// window.canvasInterop = {
//     dibujarEnCanvas: function () {
//         // Lógica para dibujar en el canvas
//         var canvas = document.getElementById('miCanvas');
//         var context = canvas.getContext('2d');
//         context.fillStyle = 'blue';
//         context.fillRect(10, 10, 50, 50);
//     }
// };

// @code{
    
// private void ParsearExpression()
//     {
        
//         BackEnd.Bib1Interop.InyectandoRuntime(JSRuntime);
//         BackEnd.Drawing.DibujarEnCanvas();
//     }
// }

// Al ejecutar el metodo ParsearExpression no se me dibuja nada en el canvas, por que sucede esto, 
// y como puedo lograr que al ejecutar BackEnd.Drawing.DibujarEnCanvas(); se me dibuje en el canvas lo que pide
// dibujarEnCanvas 