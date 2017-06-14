app.controller("myWizard", ['$scope', '$http', '$element', '$location', function ($scope, $http, $element, $location) {
    $scope.tabVal = 1;
    $scope.counter = 1;
    $scope.myProgressBar = false;
    var index;
    var myElement = {};


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
        CustomerId:"3b923e85-e767-480c-82b9-26833a6e178d",
        Name: "",
        Fields: [{
            Id: 0,
            Name: "",
            FieldTypeId: "",
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
            FieldTypeId: "",
            ConditionType: "",
            Regulation: [],
            SetDataFieldValue: "",
            DefaultFieldValue: ""
        });
        $scope.counter++;
    }

//ProgressBar 
    function move() {
        var elem = document.getElementById("myBar");
        var width = 1;
        var id = setInterval(frame, 20);
        function frame() {
            if (width >= 100) {
                width = 1;
                clearInterval(id);
            } else {
                width++;
                elem.style.width = width + '%';
            }
        }
    }


    //Finish
    function finish() {
        $scope.exampleWrite = $location.host() + "/api/Data/Set?" + $scope.finishData.Id + "&";
        $scope.exampleRead = $location.host() + "/api/Data/Read?" + $scope.finishData.Id + "&fieldKey=";

        angular.forEach($scope.finishData.Fields, function (value, key) {
            $scope.exampleWrite += value.Id + "=30" 
        });
        $scope.exampleRead += $scope.finishData.Fields[0].Id
    }


    $scope.save = function () {
        $scope.myProgressBar = true;
        move();

        for (var i = 0; i < $scope.Unit.Fields.length; i++) {
            $scope.Unit.Fields[i].Id = null;
        }

        $http.post("api/unit/Insert", $scope.Unit)
            .then(function (data) {
                $scope.finishData = data.data;
                if (data.data.Id != null) {
                    finish();
                    $scope.tabVal = 4;
                }
            });

    }

    function find(array, value) {
        for (var i = 0; i < array.length; i++) {
            if (array[i].RegulationId == value) {
                return i
            }
        }
        return null;
    }

    /*setDataField içindeki Buttons Dizisinin içindeki   buttons'ları seçereken kullanılıyor  */
    $scope.setDataFieldSelection = function setDataFieldsSelection(item,id) {
        myElement = {
            RegulationId: item.Id,
        }

        index = find($scope.Unit.Fields[id].Regulation, myElement.RegulationId);

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
