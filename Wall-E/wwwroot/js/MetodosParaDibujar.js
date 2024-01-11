function clearCanvas(canvasId) {
    var canvas = document.getElementById(canvasId);
    var context = canvas.getContext('2d');
    context.clearRect(0, 0, canvas.width, canvas.height);
}
function resizeCanvas(canvasId) {
    var canvas = document.getElementById(canvasId);
    canvas.width = canvas.offsetWidth;
    canvas.height = canvas.offsetHeight;
}

function DibujarPuntoEnCanvas( color, x, y) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración del punto (usamos las coordenadas x e y)
    var radio = 1;

    // Dibujo del punto
    ctx.beginPath();
    ctx.arc(x, y, radio, 0, 2 * Math.PI);
    ctx.fillStyle = color; // Color del punto (puedes ajustar el color)
    ctx.fill();  
    ctx.closePath();
}

function DibujarRectaEnCanvas(color,x1, y1, x2, y2) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');
    
        ctx.strokeStyle = color; // Color de la recta (puedes ajustar el color)
        ctx.lineWidth = 0.7; // Grosor de la línea (puedes ajustar el grosor)

    // Configuración de la recta
    ctx.beginPath();
    ctx.moveTo(x1, y1);

    // Verificar si la recta es vertical (paralela al eje Y)
    if (x1 === x2) {
        // Dibujar la línea hasta los extremos del canvas
        ctx.lineTo(x1, 0);
        ctx.lineTo(x1, canvas.height);
    } else {
        // Dibujar la línea hasta los extremos del canvas
        ctx.lineTo(0, CalcularYIntercept(0, x1, y1, x2, y2));
        ctx.lineTo(canvas.width, CalcularYIntercept(canvas.width, x1, y1, x2, y2));
    }
    ctx.stroke();
    ctx.closePath();
}

// Función para calcular la intersección en el eje Y
function CalcularYIntercept(x, x1, y1, x2, y2) {
    return ((x - x1) * (y2 - y1) / (x2 - x1)) + y1;
}

function DibujarSegmentoEnCanvas(color, x1, y1, x2, y2) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración del segmento (usamos las coordenadas x e y de los puntos de inicio y fin)
    ctx.beginPath();
    ctx.strokeStyle = color; // Color del segmento (puedes ajustar el color)
    ctx.lineWidth = 0.7; // Grosor de la línea (puedes ajustar el grosor)
    ctx.moveTo(x1, y1);
    ctx.lineTo(x2, y2);
    ctx.stroke();
    ctx.closePath();
}

// function DibujarRectaEnCanvas(x1, y1, x2, y2) {
//     var canvas = document.getElementById('myCanvas');
//     var ctx = canvas.getContext('2d');
    
//         ctx.strokeStyle = 'blue'; // Color de la recta (puedes ajustar el color)
//         ctx.lineWidth = 0.5; // Grosor de la línea (puedes ajustar el grosor)

//     // Configuración de la recta
//     ctx.beginPath();
//     ctx.moveTo(x1, y1);

//     // Verificar si la recta es vertical (paralela al eje Y)
//     if (x1 === x2) {
//         // Dibujar la línea hasta los extremos del canvas
//         ctx.lineTo(x1, 0);
//         ctx.lineTo(x1, canvas.height);
//     } else {
//         // Dibujar la línea hasta los extremos del canvas
//         ctx.lineTo(0, CalcularYIntercept(0, x1, y1, x2, y2));
//         ctx.lineTo(canvas.width, CalcularYIntercept(canvas.width, x1, y1, x2, y2));
//     }
//     ctx.stroke();
//     ctx.closePath();
// }

function DibujarRayoEnCanvas(canvasId, color, punto1X, punto1Y, punto2X, punto2Y) {
    var canvas = document.getElementById(canvasId);
    var ctx = canvas.getContext("2d");

    ctx.strokeStyle = color;
    ctx.lineWidth = 0.7;

    // Calcular la dirección del rayo
    var dx = punto2X - punto1X;
    var dy = punto2Y - punto1Y;

    // Dibujar el rayo
    ctx.beginPath();
    ctx.moveTo(punto1X, punto1Y);

    // Determinar el punto final del rayo
    // Usar un multiplicador grande para asegurarse de que el rayo se extienda más allá del canvas
    var multiplier = 1000;
    var endX = punto1X + dx * multiplier;
    var endY = punto1Y + dy * multiplier;

    ctx.lineTo(endX, endY);
    ctx.stroke();
}

function DibujarArcoEnCanvas(color, centroX, centroY, inicioX, inicioY, finX, finY, radio) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');
    if(inicioX==finX && inicioY==finY)
    {
        DibujarCircunferenciaEnCanvas(color, centroX, centroY, radio);
    }
    // Configuración del arco (usamos las coordenadas x e y del centro, puntos de inicio y fin, y radio)
    ctx.beginPath();
    ctx.arc(centroX, centroY, radio, Math.atan2(inicioY - centroY, inicioX - centroX), Math.atan2(finY - centroY, finX - centroX), false);
    ctx.strokeStyle = color; // Color del arco (puedes ajustar el color)
    ctx.lineWidth = 0.7; // Grosor de la línea (puedes ajustar el grosor)
    ctx.stroke();
    ctx.closePath();
}

function DibujarCircunferenciaEnCanvas(color, centroX, centroY, radio) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración de la circunferencia (usamos las coordenadas x e y del centro y el radio)
    ctx.beginPath();
    ctx.arc(centroX, centroY, radio, 0, 2 * Math.PI);
    ctx.strokeStyle = color; // Color de la circunferencia (puedes ajustar el color)
    ctx.lineWidth = 0.7; // Grosor de la línea (puedes ajustar el grosor)
    ctx.stroke();
    ctx.closePath();
}


//Meotodos para dibujar con identificadores

//esta funcion esta arreglada y ya pone el identificador debajo del punto
function DibujarPuntoEnCanvasConID( color, x, y,id) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración del punto (usamos las coordenadas x e y)
    var radio = 4;

    // Dibujo del punto
    ctx.beginPath();
    ctx.arc(x, y, radio, 0, 2 * Math.PI);
    ctx.fillStyle = color; // Color del punto (puedes ajustar el color)
    ctx.fill();  
    ctx.closePath();

    ctx.font = "14px Arial"; // Tamaño y tipo de fuente para el identificador
    ctx.fillStyle = "black"; // Color del identificador
    ctx.textAlign = "center";
    ctx.fillText(id, x, y + radio + 30); // Colocar el identificador debajo del punto
    
}

//Recta en canvas con ID
function DibujarRectaEnCanvasConID(color,x1, y1, x2, y2,identificador) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');
    
        ctx.strokeStyle = color; // Color de la recta (puedes ajustar el color)
        ctx.lineWidth = 0.7; // Grosor de la línea (puedes ajustar el grosor)

    // Configuración de la recta
    ctx.beginPath();
    ctx.moveTo(x1, y1);

    // Verificar si la recta es vertical (paralela al eje Y)
    if (x1 === x2) {
        // Dibujar la línea hasta los extremos del canvas
        ctx.lineTo(x1, 0);
        ctx.lineTo(x1, canvas.height);
    } else {
        // Dibujar la línea hasta los extremos del canvas
        ctx.lineTo(0, CalcularYIntercept(0, x1, y1, x2, y2));
        ctx.lineTo(canvas.width, CalcularYIntercept(canvas.width, x1, y1, x2, y2));
    }
    ctx.stroke();
    ctx.closePath();

    ctx.font = "14px Arial"; // Tamaño y tipo de fuente para el identificador
    ctx.fillStyle = "black"; // Color del identificador
    ctx.textAlign = "center";
    ctx.fillText(identificador, (x1 + x2) / 2, (y1 + y2) / 2 + 15); // Colocar el identificador debajo de la recta    
}

//Segmento en canvas con ID
function DibujarSegmentoEnCanvasConID(color, x1, y1, x2, y2,identificador) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración del segmento (usamos las coordenadas x e y de los puntos de inicio y fin)
    ctx.beginPath();
    ctx.strokeStyle = color; // Color del segmento (puedes ajustar el color)
    ctx.lineWidth = 0.7; // Grosor de la línea (puedes ajustar el grosor)
    ctx.moveTo(x1, y1);
    ctx.lineTo(x2, y2);
    ctx.stroke();
    ctx.closePath();
    
    ctx.font = "14px Arial"; // Tamaño y tipo de fuente para el identificador
    ctx.fillStyle = "black"; // Color del identificador
    ctx.textAlign = "center";
    ctx.fillText(identificador, (x1 + x2) / 2, (y1 + y2) / 2 + 15); // Colocar el identificador debajo de la recta
}

function DibujarRayoEnCanvasConID(canvasId, color, punto1X, punto1Y, punto2X, punto2Y,identificador) {
    var canvas = document.getElementById(canvasId);
    var ctx = canvas.getContext("2d");

    ctx.strokeStyle = color;
    ctx.lineWidth = 0.7;

    // Calcular la dirección del rayo
    var dx = punto2X - punto1X;
    var dy = punto2Y - punto1Y;

    // Dibujar el rayo
    ctx.beginPath();
    ctx.moveTo(punto1X, punto1Y);

    // Determinar el punto final del rayo
    // Usar un multiplicador grande para asegurarse de que el rayo se extienda más allá del canvas
    var multiplier = 1000;
    var endX = punto1X + dx * multiplier;
    var endY = punto1Y + dy * multiplier;

    ctx.lineTo(endX, endY);
    ctx.stroke();

    // Añadir identificador debajo del rayo
    ctx.font = "14px Arial"; // Tamaño y tipo de fuente para el identificador
    ctx.fillStyle = "black"; // Color del identificador
    ctx.textAlign = "center";
    ctx.fillText(identificador, punto1X + 30, punto1Y+30 ); // Colocar el identificador debajo del rayo

}

function DibujarArcoEnCanvasConID(color, centroX, centroY, inicioX, inicioY, finX, finY, radio,identificador ) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');
    if(inicioX==finX && inicioY==finY)
    {
        DibujarCircunferenciaEnCanvas(color, centroX, centroY, radio);
    }
    // Configuración del arco (usamos las coordenadas x e y del centro, puntos de inicio y fin, y radio)
    ctx.beginPath();
    var startAngle = Math.atan2(inicioY - centroY, inicioX - centroX);
    var endAngle = Math.atan2(finY - centroY, finX - centroX);
    var goingClockwise = Math.abs(endAngle - startAngle) > Math.PI;
    ctx.arc(centroX, centroY, radio, startAngle, endAngle, goingClockwise);
    ctx.strokeStyle = color; // Color del arco (puedes ajustar el color)
    ctx.lineWidth = 0.7; // Grosor de la línea (puedes ajustar el grosor)
    ctx.stroke();
    ctx.closePath();

    ctx.font = '14px Arial';
    ctx.fillStyle = color;
    ctx.textAlign = 'center';
    ctx.fillText(identificador, centroX, centroY  + 15);
}

//este metodo ya esta arreglado con el identificador 
function DibujarCircunferenciaEnCanvasConID(color, centroX, centroY, radio,identificador) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración de la circunferencia (usamos las coordenadas x e y del centro y el radio)
    ctx.beginPath();
    ctx.arc(centroX, centroY, radio, 0, 2 * Math.PI);
    ctx.strokeStyle = color; // Color de la circunferencia (puedes ajustar el color)
    ctx.lineWidth = 0.7; // Grosor de la línea (puedes ajustar el grosor)
    ctx.stroke();
    ctx.closePath();
    
    // Dibujar el identificador
  ctx.font = '14px Arial';
  ctx.fillStyle = color;
  ctx.textAlign = 'center';
  ctx.fillText(identificador, centroX, centroY + radio + 15);
}