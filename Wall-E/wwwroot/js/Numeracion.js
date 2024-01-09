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

function scrollSync(id1, id2) {
    let textArea1 = document.getElementById(id1);
    let textArea2 = document.getElementById(id2);

    if (textArea1 != null && textArea2 != null) {
        textArea2.scrollTop = textArea1.scrollTop;
    }
}