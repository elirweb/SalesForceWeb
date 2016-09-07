'use strict'
var myapp = angular.module('myapp', []);


// trazendo uma lista de veiculos,renavam,tipo,data
myapp.controller('veiculoscontroller', function ($scope, $http) {
    $http.get('http://localhost:61154/sales/Veiculos').success(function (response) {
        $scope.result = response;
    });
    
});



// preenchendo dados vindo de uma api para uma select
myapp.controller('tiposveiculos',['$scope','$http' ,function($scope, $http){
    $http.get('http://localhost:61154/sales/Tipos').success(function (response) {
        $scope.tipos = response;
    });
    $http.get('http://localhost:61154/sales/Modelos').success(function (response) {
        $scope.modelos = response;
    });


    // enviando dados da web para a api usando angular 
    $scope.CadastrarVeiculo = function () {

        $http({
            url: 'http://localhost:61154/sales/Cadastrar', // url da api 
            method: 'POST', // definindo metodo post
            headers: { 'Content': 'application/json;' }, // definindo o cabecalho 
            data: $scope.formcadveiculo // enviando dados do formulario via post para a api gravar no banco de dados
        })
        .success(function (data) {
            $scope.mensagem = "Usuario Cadastrado com sucesso ID de Cadastro " + data.id;
            document.getElementById("Placa").value = "";
            document.getElementById("Cor").value = "";
            document.getElementById("Renavam").value = "";
            document.getElementById("Ano").value = "";
            document.getElementById("CodigoModelo").value = document.getElementById("CodigoModelo").options[0].text;
            document.getElementById("CodigoTipo").value = document.getElementById("CodigoTipo").options[0].text;
        });
    };

    $scope.Limpar = function () {
        document.getElementById("Placa").value = "";
        document.getElementById("Cor").value = "";
        document.getElementById("Renavam").value = "";
        document.getElementById("Ano").value = "";
        document.getElementById("CodigoModelo").value = document.getElementById("CodigoModelo").options[0].text;
        document.getElementById("CodigoTipo").value = document.getElementById("CodigoTipo").options[0].text;
    };
    
}]);


