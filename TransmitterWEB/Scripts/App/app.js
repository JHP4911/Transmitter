var app = angular.module("myApp", []);
app.controller("navigationCtrl", ['$scope', '$http', function ($scope, $http) {
    $scope.tabVal = 1;
    $scope.counter = 2;
    $scope.groups = [];
    $http.get('/api/Customer/GetCustomerForNavigation/')
        .then(function (response) {
        console.log(response.data);
        $scope.groups = response.data;
    });
}]);