app.controller("profileController", ['$scope', '$http', function ($scope, $http) {
    $scope.Company = {};

    $http.get('/api/Customer/GetCustemer/')
        .then(function (response) {
            $scope.Company = response.data;
        });

    $scope.save = function (Id) {
        console.log(Id);
        $http.post('/api/Customer/Update', $scope.Company)
            .then(function (response) {
                console.log(response);
            });
    }

}]);