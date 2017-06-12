app.controller("unitController", ['$scope', '$http', function ($scope, $http) {
    $scope.fields = [];
    $scope.data = [
        {
            key: "Short",
            values: [{
                "CreateTime": "0001-01-01T00:00:00",
                "Value": "30"
            }]
        }
    ];
    $scope.initController = function (Id) {
        $http.get('/api/Unit/getUnitFieldforCharts/' + Id)
            .then(function (response) {
                $scope.fields = response.data;
                $scope.data = $scope.fields[0].fieldValue;
                console.log($scope.fields[0].fieldValue);

            });
    }

    $scope.ticksToDate = function (d) {
        var now = new Date(d)
        var str = now.getUTCDate() +
            "/" + (now.getUTCMonth() + 1).toString() +
            "/" + now.getUTCFullYear().toString() +
            " " + now.getUTCHours() +
            ":" + now.getUTCMinutes();;
        return str;
    }
    $scope.options = {
        chart: {
            type: 'lineChart',
            height: 300,
            margin: {
                top: 20,
                right: 20,
                bottom: 60,
                left: 55
            },
            x: function (d) { return d.CreateTime; },
            y: function (d) { return d.Value; },
            //  average: function (d) { return d.mean / 100; },
            xAxis: {
                rotateLabels: -45,
                ticks: 10,
                tickFormat: function (d) {
                    return d3.time.format('%d/%m/%y')(new Date(d))
                },
            },
            yAxis: {
                tickFormat: function (d) {
                    return d3.format('.0f')(d);
                },
                ticks: 5
            }
        }
    };



}]);