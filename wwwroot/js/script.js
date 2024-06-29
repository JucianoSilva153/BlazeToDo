window.MostrarMenu = () => {
    document.getElementById("MenuHumburguer").style.display = "block"
    document.getElementById("main").style.overflow = "hidden";
}

window.OcultarMenu = () => {
    document.getElementById("MenuHumburguer").style.display = "none"
    document.getElementById("main").style.overflow = "auto";
}

window.MostrarEliminarCategoria = () => {
    document.getElementById("popEliminarCategoria").style.display = "flex";
}

window.OcultarEliminarCategoria = () => {
    document.getElementById("popEliminarCategoria").style.display = "none";
}

window.OcultarMenu = () => {
    document.getElementById("Menu").classList.remove("flex");
    document.getElementById("Menu").classList.add("hidden");
}

window.MostrarMenu = () => {
    document.getElementById("Menu").classList.remove("hidden");
    document.getElementById("Menu").classList.add("flex");
}