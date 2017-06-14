app.controller("myWizard", ['$scope', '$http', '$element', function ($scope, $http, $element) {
    $scope.tabVal = 1;
    $scope.counter = 1;
   

    $scope.nextTab = function () {

        if ($scope.tabVal < 4) {
            $scope.tabVal++;
        }
    }

    $scope.prevTab = function () {
        if ($scope.tabVal > 1) {
            $scope.tabVal--;
        }
    }

    //Field
    $http.get("api/Field/getFieldType")
        .then(function (data) {
            $scope.fieldType = data.data;
        });

   
    $scope.comparisonType = ["BUYUK", "KUCUK", "ESıt", "FARKLI"];
    $scope.setData = ["Set", "SendSms", "SendNotification"]; 

    $scope.unit = {
        Name: "",
        Fields: [{
            Id: 0,
            Name: "",
            FieldType: "",
            ConditionType: "",
            Regulation: [],
            SetDataFieldValue: "",
            DefaultFieldValue:""
        }]
    };

    
   
    $scope.addRow = function () {
        $scope.unit.Fields.push({
            Id: $scope.counter,
            Name: "",
            FieldType: "",
            FieldRegulation:[ {
                Condition: "",
                CnditionType: "",
                SetDataFieldValue: [],
                DefaultFieldValue: ""
            }],
        });
        $scope.counter++;
    }


    $scope.save = function () {

        for (var i = 0; i < $scope.unit.Fields.length; i++) {
            $scope.unit.Fields[i].Id = null;
        }

        $http.post("api/Field/Insert", $scope.unit)
            .then(function (data) {
                console.log(data);
            });
        console.log($scope.unit.fields);

    }

    /*setDataField içindeki Buttons Dizisinin içindeki   buttons'ları seçereken kullanılıyor  */
    $scope.setDataFieldSelection = function setDataFieldsSelection(item,id) {

        var idx = $scope.unit.Fields[id].FieldRegulation[0].SetDataFieldValue.indexOf(item);
        // is currently selected
        if (idx > -1) {
            $scope.unit.Fields[id].FieldRegulation[0].SetDataFieldValue.splice(idx, 1);
        }

        // is newly selected
        else {
            $scope.unit.Fields[id].FieldRegulation[0].SetDataFieldValue.push(item);
        }
    };





    /**********************************************************************/
    $scope.$watch('unit', function (model) {
        $scope.modelAsJson = angular.toJson(model, true)
        //console.log("asd");
    }, true);

}]);
