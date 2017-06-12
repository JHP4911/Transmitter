var app = angular.module("myApp", ['nvd3']);
app.controller("navigationCtrl", ['$scope', '$http', function ($scope, $http) {
    $scope.tabVal = 1;
    $scope.counter = 2;
    $scope.units = [];
    $http.get('/api/Customer/GetCustomerForNavigation/')
        .then(function (response) {
        console.log(response.data);
        $scope.units = response.data;
    });
}]);