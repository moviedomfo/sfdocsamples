
(function () {
    "use strict";
   
    var app = angular.module("myApp", ["ngTable"]);
    app.controller("demoController", demoController);
    demoController.$inject = ["NgTableParams", "ngTableSimpleList"];
 
    function demoController(NgTableParams, simpleList) {
        var self = this;

        var data = [{ name: 'christian', age: 21 },
                    { name: 'anthony', age: 88 }
        ];
        
        self.tableParams = new NgTableParams({}, { dataset: data });
        //self.tableParams = new NgTableParams({}, {
        //    dataset: simpleList
        //});
        $scope.search_Fees = function () {
            var self = this;
            var data = [{ name: 'christian', age: 21 },
                   { name: 'anthony', age: 88 }
            ];

            self.tableParams = new NgTableParams({}, { dataset: data });

        }

    }
})();