var ValidaExclusao = function (id, evento) {

    if (confirm("comfirma a exclusao?")) {
        return true;
    }
    else {
        evento.preventDefault();
        return false;
    }
}