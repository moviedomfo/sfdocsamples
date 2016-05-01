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
            controllerAs: "tab" //dado q en la vista TabController as tab
        };
    });

    app.directive('productDetails', function () {
        return {
            restrict: 'E',
            templateUrl: '../pages/product-details.html'
        };
    });
})();


app.controller('myController', function ($scope) {

    $scope.products = [
        {
            name:"Mercedes-Benz",
            description: "Engine 4,966-cc SOHC 24-valve 90° V-8. High-pressure die-cast alloy cylinder block, alloy heads. "
        },
         {
             name: "Dodge",
             description: " one carryover unit are offered. A new 3.7-liter Magnum V- "
         },
          {
              name: "TRUCK-Benz",
              description: "-cab Ram is abundant, and three adults fit adequately when the im. "
          }
    ];
    $scope.cliente = {
        Name: "",
        LastName: ""
    };

    $scope.myValue = "Hi everybody";
});


app.controller("TabController", function () {
  
});