var myApp;
(function () {
    myApp = angular.module("myApp", []);
})();
myApp.controller("personController", function ($scope) {

    $scope.person = {
        "Name": "",
        "PersonId": 0,
        "Lastname": "",
        "nif": "",
        "DocNumber": "",
        "email": ""
    };

    $scope.submitForm = function (person) {
        alert('Form submitted with' + JSON.stringify($scope.person));
    };

});
//Las directivas deben tener nombre camelCase
myApp.directive('docNumberValidation', function () {
    return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            ctrl.$validators.docnumbervalidation = function (modelValue, viewValue) {


                if (ctrl.$isEmpty(modelValue)) {
                    // tratamos los modelos vacíos como correctos
                    return true;
                }

                if (viewValue) {
                    var letterValue = viewValue.substr(viewValue.length - 1);
                    

                    if (viewValue === "DOC") {
                        return true;
                    } else {
                        return false;
                    }
                }


                // NIF inválido
                return false;


            };
        }
    };
});

myApp.directive('nameValidation', function () {
    return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            ctrl.$validators.namevalidation = function (modelValue, viewValue) {


                if (ctrl.$isEmpty(modelValue)) {
                    // tratamos los modelos vacíos como correctos
                    return true;
                }

                if (viewValue) {
                    var letterValue = viewValue.substr(viewValue.length - 1);
                  

                    if (letterValue === "A") {
                        return true;
                    } else {
                        return false;
                    }
                }


                // NIF inválido
                return false;


            };
        }
    };
});



myApp.directive('nifValidation', function () {
    return {
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            ctrl.$validators.nifvalidation = function (modelValue, viewValue) {


                if (ctrl.$isEmpty(modelValue)) {
                    // tratamos los modelos vacíos como correctos
                    return true;
                }

                if (viewValue) {
                    var letterValue = viewValue.substr(viewValue.length - 1);
                    var numberValue = viewValue.substr(viewValue.length - (viewValue.length - 1));
                    var controlLetter = "TRWAGMYFPDXBNJZSQVHLCKE".charAt(numberValue % 23);
                   
                    if (letterValue === controlLetter) {
                        return true;
                    } else {
                        return false;
                    }
                }


                // NIF inválido
                return false;


            };
        }
    };
});

angular.module('docsTemplateUrlDirective', [])
.controller('personController', ['$scope', function ($scope) {
    $scope.customer = {
        name: 'Naomi',
        address: '1600 Amphitheatre'
    };
}])
.directive('myCustomer', function () {
    return {
        templateUrl: 'my-customer.html'
    };
});