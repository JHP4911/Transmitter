// this represents the state of the dialog: a visible flag and the person being edited
var EditPersonDialogModel = function () {
    this.visible = false;
};
EditPersonDialogModel.prototype.open = function (person) {
    this.person = person;
    this.visible = true;
};
EditPersonDialogModel.prototype.close = function () {
    this.visible = false;
};


app.controller("myWizard", ['$scope', '$http', '$element', function ($scope, $http, $element) {


    $scope.editDialog = new EditPersonDialogModel();
    $scope.fieldType=["Setfield","SendSms"]
    ///

    $scope.tabVal = 3;
    $scope.counter = 2;
    $scope.showHideVal = false;
    $scope.select2Options = {
        'multiple': true
    };
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


    //***
    $scope.example8model = [];
    $scope.example8data = [{ id: 1, label: "David" }, { id: 2, label: "Jhon" }, { id: 3, label: "Danny" }];
    $scope.example8settings = { checkBoxes: true, };
    //**


    //Field
    //$http.get("api/Field/getFieldType")
    //    .then(function (data) {
    //        $scope.fieldType = data.data;
    //    });

   
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
            setDataField: ["setField","setSms"],
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

app.directive('editPersonDialog', [function () {
    return {
        restrict: 'E',
        scope: {
            model: '=',
        },
        link: function (scope, element, attributes) {
            scope.$watch('model.visible', function (newValue) {
                var modalElement = element.find('.modal');
                modalElement.modal(newValue ? 'show' : 'hide');
            });

            element.on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.model.visible = true;
                });
            });

            element.on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.model.visible = false;
                });
            });

        },
        templateUrl: '/Deneme/HtmlPage1.html',
    };
}]);