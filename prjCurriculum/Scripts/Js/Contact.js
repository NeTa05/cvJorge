$('#send').click(function () {
    var email = $('#email').val();
    var message = $('#message').val();
    var name = $('#name').val();

    if (email != "" && message != "" && name != "") {
        $.ajax({
            url: '/Home/Contact',
            type: 'POST',
            data: { email: email, message: message, name: name },
        })
        .done(function (data) {
            if (data == "Enviado")
                setAlert("", data);
            if (data == "Email")
                setAlert("Correo electrónico inválido<br>", "Error");
        });
    }
    else {
        var msg = "";
        if (name == "")
            msg += "Digite nombre.<br>";
        if (message == "")
            msg += "Digite mensaje.<br>";
        if (email == "")
            msg += "Digite correo electrónico.<br>";
        setAlert(msg, "Error");
    }

});
