var myapp = angular.module('myapp', []);
myapp.controller('veiculoscontroller', function ($scope, $http) {
    $http.get('http://localhost:61154/sales/veiculo').success(function (response) {
        $scope.result = response;
    });
});