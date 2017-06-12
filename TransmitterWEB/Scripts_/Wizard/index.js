app.controller("myWizard",['$scope','$http', function ($scope,$http) {
    $scope.tabVal = 1;
    $scope.counter = 2;
    $scope.showHideVal = false;

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

    $scope.showHide = function () {
        
        $scope.showHideVal = !$scope.showHideVal;
    }



    //Field
    $http.get("api/Field/getFieldType")
        .then(function (data) {
            $scope.fieldType = data.data;
        });

   
$comparisonType=["<","<=",">",">=",""]
    

    $scope.unit = {

        name: "",
        
        fields: [{
            id: 1,
            fieldName: "",
            fieldType: "",
            conditionType: "",
            conditionValue:0,
            fieldRegulation: "",
            setDataField: [],
            defaultValue:0,
        }],
    };

    
   

    $scope.addRow = function () {
        $scope.unit.fields.push({
            id: $scope.counter,
            fieldName: "",
            fieldType: ""
        });
        $scope.counter++;
    }

    /**********************************************************************/
    $scope.$watch('unit', function (model) {
        $scope.modelAsJson = angular.toJson(model, true)
        //console.log("asd");
    }, true);

}]);