'use strict'

var myapp = angular.module('myapp', []);

myapp.controller('logincontroller', function ($scope, $http) {
    $scope.EsqueceuEmail = function () {
        $http.get('http://localhost:61154/sales/Login/Buscar/' + document.getElementById("Email").value + '/email')
            .success(function (response) {
                if (response == "")
                    $scope.retorno = "Usuario não cadastrado em nosso sistema";
                else
                    $scope.retorno = "Enviando senha para email cadastrado";
            });
    };

    $scope.RedefinirSenha = function () {
        $http({
            url: 'http://localhost:61154/sales/Login/AtualizarSenha',
            method: 'POST',
            headers: { 'Content': 'application/json;' },
            data: $scope.formSenha
        })
        .success(function(data){
            $scope.mensagem = "Senha alterada com sucesso"; 
        });
        
    };
});