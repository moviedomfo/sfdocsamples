/// <reference path="C:\projects\GitHub-sourcetree\doc_samples\WEB\angular-ng-table-Test\angularTest2\Views/Home/product-details.html" />
var app;
(function () {
    app = angular.module("myApp", []);

    app.directive("insertImage", function () {
        return {
            restrict: 'A',
            replace: false,
            template: '<div class="form-group">'
                       + '<img src="../../images/ico-24x24-11.png" /> '
                       + '</div>'
        }
    }
    );

    app.directive("busqueda", function () {
        return {
            restrict: 'E',
            scope: {
                busqueda: '@'
            },
            template: '<div class="form-group">'
                       + '<input type="text" '
                       + 'class="form-control"'
                       + 'placeholder="Introduce tu texto a buscar"'
                       + 'value={{busqueda}}'
                       + '</div>'
        }
    }
    );

    app.directive('clienteFullName', function () {
        return {
            template: '  <div class="text-primary">{{cliente.LastName}}, {{cliente.Name}} </div> '
        };
    });
    app.directive('hello', function () {
        return {
            restrict: 'A',
            template: '<div>Hi there</div>',
            replace: true
        };
    });


    app.directive('productDetails', function () {
        return {
            restrict: 'E',
            templateUrl: 'product-details.html'
        };
    });

    app.directive("productTabs", function () {
        return {
            restrict: 'E',
            templateUrl: "../pages/product-tabs.html",
            controller: function () {
                this.tab = 1;

                this.isSet = function (checkTab) {
                    return this.tab === checkTab;
                };

                this.setTab = function (setTab) {
                    this.tab = setTab;
                };
            },
            controllerAs: "tab"
        };
    });
})();


app.controller('myController', function ($scope) {

    $scope.cliente = {
        Name: "",
        LastName: ""
    };

    $scope.myValue = "Hi everybody";
});


app.controller("TabController", function () {
  
});