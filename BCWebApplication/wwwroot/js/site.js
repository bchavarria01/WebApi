function requestAsync(url, id, callback) {
    var xmlhttp = new XMLHttpRequest();
    var div = document.getElementById(id);
    var contentActual;
    try {
        //$(div).addClass("hidden");
        //$(div).after('<i class="fa fa-cog fa-spin" style="font-size: 120px; color: #007dfa;"></i>');
        contentActual = div.innerHTML;
        div.innerHTML = '<i class="fa fa-cog fa-spin" style="font-size: 120px; color: #3c8dbc;"></i>';
    } catch (err) {

    }

    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            try {
                div.innerHTML = xmlhttp.responseText;
            } catch (err) { }
            try {
                callback(xmlhttp);
            } catch (err) { }
        }
        else if (xmlhttp.readyState == 4) {
            try {
                div.innerHTML = contentActual;
                alert("La peticion al servidor fallo");
            } catch (err) { }
        }
    }
    xmlhttp.open("GET", url, true);
    xmlhttp.send();
};