﻿'use strict'

var myapp = angular.module('myapp', []);



myapp.controller('logincontroller' ,['$scope','$http', '$location', function ($scope, $http,$location) {
    $scope.EsqueceuEmail = function () {
        $http.get('http://localhost:61154/sales/Login/Buscar/' + document.getElementById("Email").value + '/email')
            .success(function (response) {
                if (response == "")
                    $scope.retorno = "Usuario não cadastrado em nosso sistema";
                else
                    $scope.retorno = "Enviando senha para email cadastrado";
            });
    };


    $scope.ComparadorSenha = function () {
        if (document.getElementById("Senha").value != document.getElementById("txtconfirma").value) {
            $scope.mensagem = "Senha não confere com a senha digitada!"
        } else {
            $scope.RedefinirSenha();
        }
    };

    // atualização de senha usando api com angular 
    $scope.RedefinirSenha = function () {
        $http({
            url: 'http://localhost:61154/sales/Login/AtualizarSenha',
            method: 'POST',
            headers: { 'Content': 'application/json;' },
            data: $scope.formSenha
        })
        .success(function (data) {
            $scope.mensagem = "Senha alterada com sucesso";
            window.location = "/Admin/Relatorio";

        });
    };
    
    // lista de itens
    $scope.listaSexo = [
        { id: 0, name: "Selecione" },
        { id: 1, name: "Masculino" },
        { id: 2, name: "Feminino" }
    ];
   
    $scope.AlterarUsuario = function () {
        $http({
            url: 'http://localhost:61154/sales/Login/AtualizarSenha',
            method: 'POST',
            headers: { 'Content': 'application/json;' },
            data: $scope.formusuario
        })
        .success(function (data) {
            $scope.mensagem = "Senha alterada com sucesso";
            window.location = "/Admin/Relatorio";

        });
    };


    $scope.AlterarDadosUsuario = function () {
        $http({
            url: 'http://localhost:61154/sales/Login/AtualizarSenha',
            method: 'POST',
            headers: { 'Content': 'application/json;' },
            data: $scope.formusuario
        })
        .success(function (data) {
            $scope.mensagem = "Dados Alterados com sucesso";
            //window.location = "/Admin/Login/DocumentoCliente";
            
        });
    };

    $scope.AlterarDocumento = function () {
        console.log($scope.formusuario);
        $http({
            url: 'http://localhost:61154/sales/Login/AtualizarDocumento',
            method: 'POST',
            headers: { 'Content': 'application/json;' },
            data: $scope.formusuario

        })
        .success(function (data) {
            $scope.mensagem = "Dados Alterados com sucesso";

        });

   
    };


    $scope.AlterarUsuarioEndereco = function () {
        $http({
            url: 'http://localhost:61154/sales/Login/AtualizarEndereco',
            method: 'POST',
            headers: { 'Content': 'application/json;' },
            data: $scope.formusuario
        })
        .success(function (data) {
            $scope.mensagem = "Dados Alterados com sucesso";

        });
    };
}]);