function DibujarPuntoEnCanvas(x, y) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración del punto (usamos las coordenadas x e y)
    var radio = 1;

    // Dibujo del punto
    ctx.beginPath();
    ctx.arc(x, y, radio, 0, 2 * Math.PI);
    ctx.fillStyle = 'red'; // Color del punto (puedes ajustar el color)
    ctx.fill();  
    ctx.closePath();
}

function DibujarRectaEnCanvas(x1, y1, x2, y2) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');
    
        ctx.strokeStyle = 'blue'; // Color de la recta (puedes ajustar el color)
        ctx.lineWidth = 0.5; // Grosor de la línea (puedes ajustar el grosor)

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

function DibujarSegmentoEnCanvas(x1, y1, x2, y2) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración del segmento (usamos las coordenadas x e y de los puntos de inicio y fin)
    ctx.beginPath();
    ctx.moveTo(x1, y1);
    ctx.lineTo(x2, y2);
    ctx.strokeStyle = 'green'; // Color del segmento (puedes ajustar el color)
    ctx.lineWidth = 2; // Grosor de la línea (puedes ajustar el grosor)
    ctx.stroke();
    ctx.closePath();
}

function DibujarRayoEnCanvas(x1, y1, x2, y2) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración del rayo
    ctx.beginPath();
    ctx.moveTo(x1, y1);

    // Verificar si el rayo es vertical (paralelo al eje Y)
    if (x1 === x2) {
        // Dibujar el rayo hasta la parte inferior o superior del canvas
        ctx.lineTo(x1, y1 < y2 ? canvas.height : 0);
    } else {
        // Calcular la intersección en el eje Y
        var intersectionY = CalcularYIntercept(x1, y1, x2, y2, canvas.width);
        
        // Dibujar el rayo hasta la intersección
        ctx.lineTo(canvas.width, intersectionY);
    }

    ctx.strokeStyle = 'orange'; // Color del rayo (puedes ajustar el color)
    ctx.lineWidth = 2; // Grosor de la línea (puedes ajustar el grosor)
    ctx.stroke();
    ctx.closePath();
}

function DibujarArcoEnCanvas(centroX, centroY, inicioX, inicioY, finX, finY, radio) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');
    if(inicioX==finX && inicioY==finY)
    {
        DibujarCircunferenciaEnCanvas(centroX, centroY, radio);
    }
    // Configuración del arco (usamos las coordenadas x e y del centro, puntos de inicio y fin, y radio)
    ctx.beginPath();
    ctx.arc(centroX, centroY, radio, Math.atan2(inicioY - centroY, inicioX - centroX), Math.atan2(finY - centroY, finX - centroX), false);
    ctx.strokeStyle = 'purple'; // Color del arco (puedes ajustar el color)
    ctx.lineWidth = 2; // Grosor de la línea (puedes ajustar el grosor)
    ctx.stroke();
    ctx.closePath();
}

function DibujarCircunferenciaEnCanvas(centroX, centroY, radio) {
    var canvas = document.getElementById('myCanvas');
    var ctx = canvas.getContext('2d');

    // Configuración de la circunferencia (usamos las coordenadas x e y del centro y el radio)
    ctx.beginPath();
    ctx.arc(centroX, centroY, radio, 0, 2 * Math.PI);
    ctx.strokeStyle = 'red'; // Color de la circunferencia (puedes ajustar el color)
    ctx.lineWidth = 2; // Grosor de la línea (puedes ajustar el grosor)
    ctx.stroke();
    ctx.closePath();
}