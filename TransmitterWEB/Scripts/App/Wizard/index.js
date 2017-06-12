app.controller("myWizard", function ($scope) {
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

    $scope.fieldType = ["String","Location","Int","Double"];

    $scope.unit = {

        name: "",
        fields: [{
            id: 1,
            fieldName: "",
            fieldType: "",
        }],
    };

    //$scope.rows=[{
    //    id: 1,
    //    fieldName: "",
    //    fieldType: "",

    //}];
   

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

});