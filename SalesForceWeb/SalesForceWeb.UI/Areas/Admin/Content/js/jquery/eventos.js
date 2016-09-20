var AuthenticarUsuario = function () {
    var dados = $("#FormUsuario").serialize();
    $.ajax({
        url: '/Admin/Login',
        type: 'post',
        datatype: 'json',
        cache: false,
        method: 'post',
        data: dados,
        success: function (data, textSaudacoes) {
            if (data.indexOf("Erro!") == 0)
                $("#mensagem").text(data);
            else
                $("#mensagem").text("Redirecionando");
        }
        
    });
};

var DeslogarSistema = function () {
    if (confirm("Deseja mesmo sair do Sistema")) {
        window.location = "/Admin/Login/Deslogar";

    }
};