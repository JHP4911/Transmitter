app.controller("myWizard", ['$scope', '$http', '$element', function ($scope, $http, $element) {

     
    ///

    $scope.tabVal = 1;
    $scope.counter = 2;
   

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
        name: "",
        fields: [{
            id: 0,
            name: "",
            fieldType: "",
            fieldRegulation: {
                condition:"",
                conditionType: "",
                setDataField: [],
                defaultFieldValue:""
            },
        }]
    };

    
   

    $scope.addRow = function () {
        $scope.unit.fields.push({
            id: $scope.counter,
            fieldName: "",
            fieldType: ""
        });
        $scope.counter++;
    }



    /*setDataField içindeki Buttons Dizisinin içindeki   buttons'ları seçereken kullanılıyor  */
    $scope.setDataFieldSelection = function setDataFieldsSelection(item,id) {

        var idx = $scope.unit.fields[id].fieldRegulation.setDataField.indexOf(item);
        // is currently selected
        if (idx > -1) {
            $scope.unit.fields[id].fieldRegulation.setDataField.splice(idx, 1);
        }

        // is newly selected
        else {
            $scope.unit.fields[id].fieldRegulation.setDataField.push(item);
        }
    };





    /**********************************************************************/
    $scope.$watch('unit', function (model) {
        $scope.modelAsJson = angular.toJson(model, true)
        //console.log("asd");
    }, true);

}]);
