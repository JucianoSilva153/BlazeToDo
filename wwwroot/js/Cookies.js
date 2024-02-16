window.CriaCookie = (nome, valor, tempoEmDias) => {
    var expira = "";
    if(tempoEmDias){
        var data =new Date();
        data.setTime(data.getTime() + (tempoEmDias * 24 * 60 * 60 * 1000));
        expira = "; expires=" + data.toUTCString();
    }
    document.cookie = nome + "=" + valor + expira + "; path=/";
};

window.RetornaCookie = (nome) => {
    var nameEQ = nome + "=";
    var cookies = document.cookie.split(';');
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i];
        while (cookie.charAt(0) == ' ') {
            cookie = cookie.substring(1, cookie.length);
        }
        if (cookie.indexOf(nameEQ) == 0) {
            return cookie.substring(nameEQ.length, cookie.length);
        }
    }
    return "";
};

window.RemoveCookie = (nome) => {
    document.cookie = nome + '=; Max-Age=-99999999;';
};