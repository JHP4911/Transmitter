app.controller("dashboardController", ['$scope', '$http', function ($scope, $http) {
    $scope.fields = [];
    $http.get('/api/DashBoard/getCharts/')
        .then(function (response) {
            $scope.fields = response.data;
            console.log($scope.fields[0].fieldValue);

        });
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