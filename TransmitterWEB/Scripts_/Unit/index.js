app.controller("unitController", ['$scope', '$http', function ($scope, $http) {
    $scope.fields = [];

    $scope.sendDashBoard = function (Id) {
        console.log(Id);
        $http.post('/api/DashBoard/addChart', { fieldId: Id })
            .then(function (response) {

                console.log(response);

            });
    }

    $scope.initController = function (Id) {
        $http.get('/api/Unit/getUnitFieldforCharts/' + Id)
            .then(function (response) {
                $scope.fields = response.data;
                console.log($scope.fields[0].fieldValue);

            });
    }
    $scope.options = {
        series: {
            color: "#3c8dbc",
            lines: { show: true },
            points: { show: true }
        },
        grid: {
            color: "#555555",
            show: true,
            hoverable: true,
            borderColor: "#000000",
        },
        xaxis: {
            mode: 'categories',
            tickLength: 0
        }
    };

}]);