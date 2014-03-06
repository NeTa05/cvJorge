function setAlert(msg, type) {
    if (type == "Enviado") {
        $('#divAlert').html('<div id="alert" class="alert"><a class="close" id="closeAlert" data-dismiss="alert">×</a><span>' + type + '</span></div>');
        $('#divAlert').removeClass("alert alert-danger").addClass("alert alert-info");
    }
    else {
        $('#divAlert').html('<div id="alert" class="alert"><a class="close" id="closeAlert" data-dismiss="alert">×</a><span>' + msg + '</span></div>');
        $('#divAlert').removeClass("alert alert-info").addClass("alert alert-danger");
    }
    var jsonCSS = {
        'text-align': 'center',
        'width': '40%',
        'margin-left': '30%',
        'display': 'block'
    }
    $('#divAlert').css(jsonCSS);
}
$(document).on("click", "#closeAlert", function () {
    $("#divAlert").css("display", "none");
});