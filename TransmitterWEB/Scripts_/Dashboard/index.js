app.controller("dashboardController", ['$scope', '$http', function ($scope, $http) {
    $scope.fields = [];
    $http.get('/api/DashBoard/getCharts/')
        .then(function (response) {
            $scope.fields = response.data;
        });

    $scope.deleteDashBoard = function (field) {
        var index = $scope.fields.indexOf(field);
        $scope.fields.splice(index, 1);
        $http.post('/api/DashBoard/deleteChart', { Id: field.Id })
            .then(function (response) {
                console.log(response);
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