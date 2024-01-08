// numeracion.js

function Numeracion() {
    let eArea = document.getElementById('areaNumeracion');
    let eArea2 = document.getElementById('txCodigo');
    let numeros = eArea2.value.split("\n").length;
    let msj = "";
    for (let i = 0; i < numeros; i++) {
        msj += (i + 1) + " ◈\n";
    }
    eArea.value = msj;
}

