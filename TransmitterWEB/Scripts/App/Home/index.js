var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope) {
    $scope.deneme = "asdas";
    $scope.tabVal = 1;

    $scope.nextTab = function () {

        if ($scope.tabVal < 3) {
            $scope.tabVal++;
        }

    }


    $scope.rows=[{
        id: 1,
        fieldName: "",
        fieldType: "",

    }
       
    ];
   
    $scope.counter = 2;

    $scope.addRow = function () {

       
       

        $scope.rows.push({
            id: $scope.counter,
            fieldName: "",
            fieldType: ""
        });
        $scope.counter++;
    }

    /**********************************************************************/
    $scope.$watch('rows', function (model) {
        $scope.modelAsJson = angular.toJson(model, true)
        console.log("asd");
    }, true);

});