app.controller("unitController", ['$scope', '$http', function ($scope, $http) {
    $scope.options = {
        chart: {
            type: 'lineChart',
            height: 200,
            margin: {
                top: 20,
                right: 20,
                bottom: 40,
                left: 55
            },
            x: function (d) { return d.x; },
            y: function (d) { return d.y; },
            xAxis: {                
                rotateLabels: -45,
                ticks: d3.time.days,
                axisLabel: '',
                tickFormat: function (d) {
                    return d3.time.format('%Y-%m-%d')(new Date(d));
                },
                showMaxMin: false,
            },
            yAxis: {
                axisLabel: 'Voltage (v)',
                tickFormat: function (d) {
                    return d3.format('.02f')(d);
                },
                ticks:5
            }
        }      
    };


    $scope.data = sinAndCos();

    function sinAndCos() {
        var sin = [], sin2 = [],
            cos = [];

        var now = new Date();
        var daysOfYear = [];
        for (var d = new Date(2012, 0, 1); d <= now; d.setDate(d.getDate() + 1)) {
           // daysOfYear.push(new Date(d));
            sin.push({ x: new Date(d), y: Math.random(10)*10 });
        }

        //Data is represented as an array of {x,y} pairs.
        for (var i = 0; i < 100; i++) {
           // sin.push({ x: i, y: Math.sin(i / 10) });
            sin2.push({ x: i, y: i % 10 == 5 ? null : Math.sin(i / 10) * 0.25 + 0.5 });
            cos.push({ x: i, y: .5 * Math.cos(i / 10 + 2) + Math.random() / 10 });
        }

        //Line chart data should be sent as an array of series objects.
        return [
            {
                values: sin,      //values - represents the array of {x,y} data points
                key: 'Sine Wave', //key  - the name of the series.
                color: '#ff7f0e',  //color - optional: choose your own line color.
                strokeWidth: 2,
                classed: 'dashed'
            }
        ];
    };
}]);