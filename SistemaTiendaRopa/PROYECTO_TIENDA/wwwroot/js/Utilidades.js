function ModalFunction(DivModal) {
    if (DivModal.style.opacity == 0) {
        DivModal.style.transition = "all ease 1s";
        DivModal.style.opacity = 1;
        DivModal.style.pointerEvents = "all";

    } else {

        DivModal.style.transition = "all ease 1s";
        DivModal.style.opacity = 0;
        DivModal.style.pointerEvents = "none";
    }
}
function FormatoFechaGuardar(f) {
    const fecha = new Date(f).toISOString()
    console.log(fecha)
    return fecha
}

function FormatoFechaEditar(f) {
    const fecha = new Date(f).toISOString().substring(0, 10)
    console.log(fecha)
    return fecha
}
