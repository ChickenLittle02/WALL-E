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
    if (numeros != 0) {
        if (numeros > 9) {
            eArea.style.width = "60px";
        }
        else if (numeros > 99) {
            eArea.style.width = "90px";
        }
        else {
            eArea.style.width = "40px";
        }
    }
}

function scrollSync(id1, id2) {
    document.getElementById(id1).scrollTop = document.getElementById(id2).scrollTop;
}
