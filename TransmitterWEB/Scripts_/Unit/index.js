app.controller("unitController", ['$scope', '$http','$location', function ($scope, $http,$location) {

    $scope.fields = [];
    $scope.regulationCount = 0;
    $scope.conditionType = ["BUYUK", "KUCUK", "ESIT", "FARKLI"];
    ///Regulation
    $http.get("../api/Regulation/GetAll")
        .then(function (data) {
            $scope.regulation = data.data;
            //console.log($scope.regulation);

        });

    $scope.delete = function (Id) {
        console.log($scope.fields)
        $http.get("../api/Unit/DeleteUnit/"+ Id)
         .then(function (response) {
             window.location = "/";
         });
    }
    $scope.editField = function (Id) {
        $http.get("../api/Field/GetById/"+Id)
            .then(function (response) {

                $scope.editFieldData = response.data;
                $scope.regulationCount = $scope.editFieldData.Regulation.length;

                //console.log("----");
               // console.log($scope.editFieldData);

                //angular.element('#myModal').show();
                $('#myModal').modal();
            }
            );
    }

    $scope.save = function () {
        $http.post("../api/Unit/Update", $scope.editFieldData)
            .then(function (response) {
                
            });

    };
    $scope.regulationIdCheck = function (id) {

    };

    function find(array, value) {
        for (var i = 0; i < array.length; i++) {
            if (array[i].RegulationId == value) {
                return i
            }
        }
        return null;
    }

     /*setDataField içindeki Buttons Dizisinin içindeki   buttons'ları seçereken kullanılıyor  */
    $scope.setDataFieldSelection = function setDataFieldsSelection(item) {
        myElement = {
            RegulationId: item.Id,
        }


        //console.log($scope.editFieldData.Regulation.indexOf(item.Id));

        index = find($scope.editFieldData.Regulation, myElement.RegulationId);

        if ($scope.editFieldData.Regulation == 0) {
            $scope.editFieldData.Regulation.push(myElement);
        }
        else {

            if (index==null) {
                $scope.editFieldData.Regulation.push(myElement);
            }
            else {
                $scope.editFieldData.Regulation.splice(index,1);   
            }
        }
        $scope.regulationCount = $scope.editFieldData.Regulation.length;
    };







    $scope.sendDashBoard = function (Id) {
        console.log(Id);
        $http.post('/api/DashBoard/addChart', { fieldId: Id })
            .then(function (response) {

               // console.log(response);

            });
    }

    $scope.initController = function (Id) {
        $http.get('/api/Unit/getUnitFieldforCharts/' + Id)
            .then(function (response) {
                $scope.fields = response.data;
                //console.log($scope.fields[0].fieldValue);

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


    /**********************************************************************/
    $scope.$watch('editFieldData', function (model) {
        $scope.modelAsJson = angular.toJson(model, true)
        //console.log("asd");
    }, true);

}]);