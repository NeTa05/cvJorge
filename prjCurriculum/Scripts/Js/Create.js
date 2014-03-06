$('#send').click(function () {
    var name        =  $('#name').val();
    var telephone   =  $('#telephone').val();
    var email       =  $('#email').val();
    var comment     =  $('#comment').val();
    var index       =  telephone.length;

    if (name != "" && !isNaN(telephone) && telephone.length>=8  && email != "" && comment != "") {
        $.ajax({
            url: '/Home/Create',
            type: 'POST',
            data: {
                name: name,
                telephone: telephone,
                email: email,
                comment: comment,
            }
        })
        .done(function (data) {
            if (data == "Enviado")
                setAlert("", data);
            if (data == "Email")
                setAlert("Correo electrónico inválido<br>", "Error");
            if (data == "")
                setAlert("Faltan datos<br>", "Error");
        });
        
    }
    else {
        var msg   =  "";
        if (name == "")
            msg += "Digite nombre.<br>";
        if (telephone.length <8)
            msg += "El teléfono debe contener 8 o más números .<br>";
        if (email == "")
            msg += "Digite correo electrónico.<br>";
        if (comment == "")
            msg += "Digite comentario.<br>";
        setAlert(msg, "Error");
    }
    
});

