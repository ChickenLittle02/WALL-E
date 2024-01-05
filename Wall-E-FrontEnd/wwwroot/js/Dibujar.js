window.setupPaperJs = function(canvasId) {
    paper.install(window);
    paper.setup(canvasId);
}



window.crearPuntoEnCanvas = function(x,y) {
        // Dibujar un punto en el lienzo utilizando Paper.js
        var punto = new paper.Path.Circle(new paper.Point(x, y), 3);
        punto.fillColor = 'black';
}

window.crearPuntoConIdentificadorEnCanvas = function(x, y, identificador) {
    // Dibujar un punto en el lienzo utilizando Paper.js
    var punto = new paper.Path.Circle(new paper.Point(x, y), 3);
    punto.fillColor = 'black';

    // Mostrar el identificador del punto en el lienzo
    var text = new paper.PointText(new paper.Point(x + 5, y + 5));
    text.justification = 'left';
    text.fillColor = 'black';
    text.content = identificador;
}

window.dibujarSegmento = function(puntoInicialX, puntoInicialY, puntoFinalX, puntoFinalY, color, grosor) {
    var path = new paper.Path();
    path.strokeColor = color;
    path.strokeWidth = grosor;
    path.add(new paper.Point(puntoInicialX, puntoInicialY));
    path.add(new paper.Point(puntoFinalX, puntoFinalY));
}

//No FUNCIONAAAAAAAA
window.dibujarArco = function(canvasId, punto1X, punto1Y, punto2X, punto2Y, punto3X, punto3Y) {
    var canvas = document.getElementById(canvasId);
    paper.setup(canvas);

    // Crear puntos a partir de las coordenadas
    var punto1 = new paper.Point(punto1X, punto1Y);
    var punto2 = new paper.Point(punto2X, punto2Y);
    var punto3 = new paper.Point(punto3X, punto3Y);

    // Calcular el centro y el radio de la circunferencia
    var centro = punto1;
    var radio = punto2.getDistance(centro);

    // Calcular el ángulo entre los vectores formados por los radios
    var vector1 = punto2.subtract(centro);
    var vector2 = punto3.subtract(centro);
    var angulo = vector2.angle-vector1.angle;

    // Dibujar el arco a partir del ángulo y los radios
    var startAngle = vector1.angle;
    var endAngle = startAngle + angulo;
    var arco = new paper.Path.Arc({
        from: punto2,
        through: punto3,
        to: punto3,
        strokeColor: 'black', // Color del contorno del arco
        strokeWidth: 2,
        fillColor: 'lightgray', // Color del relleno del arco
        start: startAngle,
        end: endAngle
    });

    paper.view.draw();
}

window.dibujarLineaConDosPuntos = function(canvasId, x1, y1, x2, y2, color, grosor) {
    var canvas = document.getElementById(canvasId);
    paper.setup(canvas);

    var path = new paper.Path();
    path.strokeColor = color;
    path.strokeWidth = grosor;

    // Definir los puntos
    var startPoint = new paper.Point(x1, y1);
    var endPoint = new paper.Point(x2, y2);

    // Crear la línea y dibujarla
    path.moveTo(new paper.Point(0, calcularYParaX(startPoint, endPoint, 0)));
    path.lineTo(new paper.Point(canvas.width, calcularYParaX(startPoint, endPoint, canvas.width)));
}

function calcularYParaX(startPoint, endPoint, x) {
    if (startPoint.x === endPoint.x) {
        // Si las coordenadas x son iguales, la pendiente es indefinida (línea vertical)
        // En este caso, simplemente devolvemos la coordenada y del punto de inicio
        return startPoint.y;
    } else if (startPoint.y === endPoint.y) {
        // Si las coordenadas y son iguales, la línea es horizontal
        // En este caso, simplemente devolvemos la coordenada y del punto de inicio (o del punto final, ya que ambos tienen la misma coordenada y)
        return startPoint.x;
    }else {
        // Calcular la pendiente
        var m = (endPoint.y - startPoint.y) / (endPoint.x - startPoint.x);
        // Calcular la coordenada y para el punto x
        return startPoint.y + m * (x - startPoint.x);
    }
}

window.dibujarCircunferencia = function(canvasId, centroX, centroY, radio) {
    var canvas = document.getElementById(canvasId);
    paper.setup(canvas);

    var centro = new paper.Point(centroX, centroY);

    // Crear una circunferencia utilizando el centro y el radio
    var circunferencia = new paper.Path.Circle({
        center: centro,
        radius: radio,
        strokeColor: 'black' // Color del contorno de la circunferencia
    });

    paper.view.draw();
}
window.dibujarArcoConAngulo = function(canvasId, x1, y1, x2, y2, x3, y3, color, grosor) {
    var canvas = document.getElementById(canvasId);
    paper.setup(canvas);

    // Definir los puntos
    var punto1 = new paper.Point(x1, y1);
    var punto2 = new paper.Point(x2, y2);
    var punto3 = new paper.Point(x3, y3);
    
    crearPuntoConIdentificadorEnCanvas(x1, y1, "point1"); // Llamada al método para dibujar el primer punto con identificador
    crearPuntoConIdentificadorEnCanvas(x2, y2, "point2");
    crearPuntoConIdentificadorEnCanvas(x3, y3, "point3");

      // Calculamos los vectores
  const vector1 = new paper.Point(punto2).subtract(punto1);
  const vector2 = new paper.Point(punto3).subtract(punto1);

  

    // Calculamos el ángulo entre los vectores en radianes
    const angulo1 = vector1.angle;
    const angulo2 = vector2.angle;
    let angulo = angulo2 - angulo1;
    if (angulo < 0) {
      angulo += 360; // Asegurémonos de que el ángulo sea positivo
    }
  
    // Convertimos el ángulo a grados
    angulo = (angulo * 180) / Math.PI;
  
    // Dibujamos el arco
    // const start = new paper.Point(punto2);
    // const mid = start.add(vector1.normalize(100)); // Puedes ajustar la longitud del radio
    // const end = start.add(vector2.normalize(100)); // Igual aquí
  
    // const arco = new paper.Path.Arc(start, mid, end);


      // Dibujamos el arco
  const start = new paper.Point(punto2);
  const end = new paper.Point(punto3);  // Nuevo: Definimos el punto final del arco directamente como punto3

  // Para el punto medio, podemos tomar el punto medio entre los puntos start y end
  const mid = start.add(end).divide(2);

  const arco = new paper.Path.Arc(start, mid, end);
  
    // Ahora puedes hacer cualquier cosa con el arco, como cambiar el color, grosor de línea, etc.
    arco.strokeColor = 'black';
}

function drawArcBetweenPointsPaperJS(canvasId, x1, y1, x2, y2, x3, y3, color, radius ) {
    var strokeWidth = 2;
    var center = new paper.Point(x1, y1);
    var pointB = new paper.Point(x2, y2);
    var pointC = new paper.Point(x3, y3);
    
    crearPuntoConIdentificadorEnCanvas(x1, y1, "center"); // Llamada al método para dibujar el primer punto con identificador
    crearPuntoConIdentificadorEnCanvas(x2, y2, "pointB");
    crearPuntoConIdentificadorEnCanvas(x3, y3, "pointC");
    
    // Dibujamos el arco utilizando Paper.js
    var startAngle = (pointB.subtract(center)).angle;
    var endAngle = (pointC.subtract(center)).angle;
  
    // Calcular el ángulo de giro para asegurarnos de que el arco sea dibujado en la dirección correcta
    var sweepAngle = endAngle - startAngle;
    if (sweepAngle < 0) {
      sweepAngle += 360;
    }
  
    // Crear un punto medio y calcular el inicio y el final del arco
    var middlePoint = center.add((pointB.subtract(center).add(pointC.subtract(center))).divide(2));
    var startPoint = center.add((pointB.subtract(center)).normalize(radius));
    var endPoint = center.add((pointC.subtract(center)).normalize(radius));
  
    // Dibujar el arco con Paper.js
    var arc = new paper.Path.Arc(startPoint, middlePoint, endPoint);
    arc.strokeColor = color;
    arc.strokeWidth = strokeWidth;
  }
  