'use strict'
var myapp = angular.module('myapp', []);

// trazendo uma lista de veiculos,renavam,tipo,data
myapp.controller('veiculoscontroller', function ($scope, $http, $rootScope) {
    $http.get('http://localhost:61154/sales/Veiculo/Veiculos').success(function (response) {
        $rootScope.result = response;
    });

    // lista de itens
    $scope.listaitem = [
        { id: 1, name: "Tipo" },
        { id: 2, name: "Marca" },
        {id:3 , name:"Modelo"}
    ];


    // buscar por tipo 
    $scope.PesquisarPorTipo = function (valor) {
        if (valor == 1)
            document.getElementById("txtcampopesq").value = "Por Tipo";
        else if(valor == 2)
            document.getElementById("txtcampopesq").value = "Por Marca";
        else if (valor == 3)
            document.getElementById("txtcampopesq").value = "Por Modelo";
    };

    $scope.Localizar = function () {
        if(document.getElementById("tp_pesquisa").value == "1"){
            $http.get('http://localhost:61154/sales/Veiculo/PeloTipo/' + document.getElementById("txtcampopesq").value.trim()).
                success(function (response) {
                    if (response == "")
                        $rootScope.informacao_consulta = "A sua pesquisa não retornou nenhuma informação.";
                    else {
                        $rootScope.result = response;
                        $rootScope.informacao_consulta = "";
                    }
                // $rootScope variavel gloal angular js
                console.log(response);
            });
        }

        else if(document.getElementById("tp_pesquisa").value == "2"){
            $http.get('http://localhost:61154/sales/Veiculo/PelaMarca/' + document.getElementById("txtcampopesq").value).
                success(function (response) {
                    if (response == "")
                        $rootScope.informacao_consulta = "A sua pesquisa não retornou nenhuma informação.";
                    else {
                        $rootScope.result = response;
                        $rootScope.informacao_consulta = "";
                    }
            });
        }
        else if (document.getElementById("tp_pesquisa").value == "3") {
            $http.get('http://localhost:61154/sales/Veiculo/PeloModelo/' + document.getElementById("txtcampopesq").value).
                success(function (response) {
                    if (response == "")
                        $rootScope.informacao_consulta = "A sua pesquisa não retornou nenhuma informação.";
                    else {
                        $rootScope.result = response;
                        $rootScope.informacao_consulta = "";
                    }
                });
        } 
     };
});


// preenchendo dados vindo de uma api para uma select
myapp.controller('tiposveiculos',['$scope','$http' ,function($scope, $http){
    $http.get('http://localhost:61154/sales/Veiculo/Tipos').success(function (response) {
        $scope.tipos = response;
    });
    $http.get('http://localhost:61154/sales/Veiculo/Modelos').success(function (response) {
        $scope.modelos = response;
    });


    // enviando dados da web para a api usando angular 
    $scope.CadastrarVeiculo = function () {
        $http({
            url: 'http://localhost:61154/sales/Veiculo/Cadastrar', // url da api 
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

