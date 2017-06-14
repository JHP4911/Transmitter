app.controller("myWizard", ['$scope', '$http', '$element', function ($scope, $http, $element) {
    $scope.tabVal = 1;
    $scope.counter = 1;
    var index;
    var myElement= {};


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

    ///Regulation
    $http.get("api/Regulation/GetAll")
        .then(function (data) {
            $scope.regulation = data.data;
        });

   
    $scope.comparisonType = ["BUYUK", "KUCUK", "ESıt", "FARKLI"];
    $scope.setData = ["Set", "SendSms", "SendNotification"]; 

    $scope.Unit = {
        Name: "",
        Fields: [{
            Id: 0,
            Name: "",
            FieldType: "",
            ConditionType: "",
            Regulation: [],
            SetDataFieldValue: "",
            DefaultFieldValue: ""
        }]
    };

    
   
    $scope.addRow = function () {
        $scope.Unit.Fields.push({
            Id: $scope.counter,
            Name: "",
            FieldType: "",
            ConditionType: "",
            Regulation: [],
            SetDataFieldValue: "",
            DefaultFieldValue: ""
        });
        $scope.counter++;
    }


    $scope.save = function () {

        for (var i = 0; i < $scope.Unit.Fields.length; i++) {
            $scope.Unit.Fields[i].Id = null;
        }

        $http.post("api/unit/Insert", $scope.Unit)
            .then(function (data) {
                console.log(data);
            });
        console.log($scope.Unit.fields);

    }

    function find(array, value) {
        for (var i = 0; i < array.length; i++) {
            if (array[i].Name == value) {
                return i
            }
        }
        return null;
    }

    /*setDataField içindeki Buttons Dizisinin içindeki   buttons'ları seçereken kullanılıyor  */
    $scope.setDataFieldSelection = function setDataFieldsSelection(item,id) {
        myElement = {
            Id: item.Id,
            Name: item.Name,
        }

        index = find($scope.Unit.Fields[id].Regulation, myElement.Name);

        if ($scope.Unit.Fields[id].Regulation == 0) {
            $scope.Unit.Fields[id].Regulation.push(myElement);
        }
        else {

            if (index==null) {
                $scope.Unit.Fields[id].Regulation.push(myElement);
            }
            else {
                $scope.Unit.Fields[id].Regulation.splice(index,1);   
            }
        }
    };





    /**********************************************************************/
    $scope.$watch('Unit', function (model) {
        $scope.modelAsJson = angular.toJson(model, true)
        //console.log("asd");
    }, true);

}]);
