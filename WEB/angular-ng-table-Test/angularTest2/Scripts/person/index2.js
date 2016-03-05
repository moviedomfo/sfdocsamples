
(function () {
    "use strict";

    var app = angular.module("myApp", ["ngTable", "ngTableDemos"]);

    app.controller("demoController", demoController);
    demoController.$inject = ["NgTableParams", "ngTableSimpleList"];

    function demoController(NgTableParams, simpleList) {
        var self = this;
        self.tableParams = new NgTableParams({}, {
            dataset: simpleList
        });
    }
})();
//(function() {
//    "use strict";
//    angular.module('myApp', ["ngRoute","ngTable"]);
//    angular.module("myApp").controller("demoController", demoController);
//    //angular.module('myApp', ['ngRoute', 'ngTable', 'ngSocial', 'embedCodepen', 'ngSanitize'])
//    //var app = angular.module('myApp', ['ngRoute','ngTable', 'ngTableDemos']);
//    //app.controller("demoController", demoController);

//    demoController.$inject = ["NgTableParams", "ngTableSimpleList"];

//    function demoController(NgTableParams, simpleList) {

//        this.tableParams = new NgTableParams({}, {
//            dataset: simpleList
//        });


//        $scope.search_Fees = function (viewAll) {
//            var self = this;
//            var f1 = $.date_convert_ddmmyyy_to_iso($scope.startDate);
//            var f2 = $.date_convert_ddmmyyy_to_iso($scope.endDate);
//            if (f1 > f2) {
//                alert('La fecha inicial no puede ser mayor que la fecha final');
//                return;
//            }

//            var varData = {
//                StartDate: f1,
//                EndDate: f2,
//                Nombre: '',
//                Apellido: ''
//            }
//            //search_Fees(varData);

//            $.ajax({
//                type: 'POST',
//                // url: httpHost + '@Url.Action("SearchByParam")',
//                url: httpHost + '/person/person/SearchByParam',
//                dataType: 'json',
//                contentType: "application/json;charset=utf-8",
//                data: JSON.stringify(varData),
//                success: function (result) {

//                    var data = result;
//                    self.tableParams = new NgTableParams({}, { dataset: data });
//                },
//                error: function ServiceFailed(xhr, status, p3, p4) {
//                    var errMsg = status + " " + p3;
//                    errMsg = errMsg + "\n" + xhr.responseText;
//                    alert(errMsg);
//                    Showloading(false);
//                }
//            });
//            //var self = this;
//            //var data = [{ name: "Moroni", age: 50 } /*,*/];
//            //self.tableParams = new NgTableParams({}, { dataset: data });
//        }
//        var currentDate = new Date();
//        $scope.endDate = currentDate.format("dd/mm/yyyy");
//        currentDate.setMonth(currentDate.getMonth() - 2);
//        $scope.startDate = currentDate.format("dd/mm/yyyy");

       

//        //fecha fin mayor fecha inicio
//        $scope.dateEndGreaterThan = true;
//        //fecha inicio mayor fecha inicio
//        $scope.dateStartLessThan = true;
//        $scope.onChangeEndDate = function () {


//            var f1 = $.date_convert_ddmmyyy_to_iso($scope.startDate);
//            var f2 = $.date_convert_ddmmyyy_to_iso($scope.endDate);
//            if (f2 >= f1)
//            {
//                $scope.dateEndGreaterThan = true;
//            }
//            else
//            { $scope.dateEndGreaterThan = false; }

//            $scope.dateStartLessThan = true;
//        }
//        $scope.onChangeStartDate = function () {

//            var f1 = $.date_convert_ddmmyyy_to_iso($scope.startDate);
//            var f2 = $.date_convert_ddmmyyy_to_iso($scope.endDate);
//            if (f2 >= f1) {
//                $scope.dateStartLessThan = true;
//            }
//            else {
//                $scope.dateStartLessThan = false;
//            }

//            $scope.dateEndGreaterThan = true;
//        }

//    }
//})();

//(function() {
//    //"use strict"; Defines that JavaScript code should be executed in "strict mode". 
//    //it is new in JavaScript 1.8.5, With strict mode, you can not, for example, use undeclared variables.
//    "use strict";

//    angular.module("myApp").controller("dynamicDemoController", dynamicDemoController);
//    dynamicDemoController.$inject = ["NgTableParams", "ngTableSimpleList"];

//    function dynamicDemoController(NgTableParams, simpleList) {
//        var self = this;
    
//        self.cols = [
//          { field: "name", title: "Name", sortable: "name", filter: { name: "text" }, show: true },
//          { field: "age", title: "Age", sortable: "age", filter: { age: "number" }, show: true },
//          { field: "money", title: "Money", sortable: "money", filter: { money: "number" }, show: true }
//        ];
//        self.tableParams = new NgTableParams({}, {
//            dataset: simpleList
//        });
//    }
//})();

//var myAppModule = angular.module('myApp', ["ngTable"]);
//angular.module("myApp", ["ngTable"]);

//myAppModule.controller('myController', ['$scope', 'ngTable', function($scope, ngTable) {
////myAppModule.controller('myController', function ($scope) {

//    var currentDate = new Date();
//    $scope.endDate = currentDate.format("dd/mm/yyyy");
//    currentDate.setMonth(currentDate.getMonth() - 2);
//    $scope.startDate = currentDate.format("dd/mm/yyyy");

    

   
//    $scope.search_Fees = function (viewAll) {
//        var self = this;
//        var f1 = $.date_convert_ddmmyyy_to_iso($scope.startDate);
//        var f2 = $.date_convert_ddmmyyy_to_iso($scope.endDate);
//        if (f1 > f2) {
//            alert('La fecha inicial no puede ser mayor que la fecha final');
//            return;
//        }
      
//            var varData = {
//                StartDate: f1,
//                EndDate: f2,
//                Nombre: '',
//                Apellido:''
//            }
//            //search_Fees(varData);

//            $.ajax({
//                type: 'POST',
//                // url: httpHost + '@Url.Action("SearchByParam")',
//                url: httpHost + '/person/person/SearchByParam',
//                dataType: 'json',
//                contentType: "application/json;charset=utf-8",
//                data: JSON.stringify(varData),
//                success: function (result) {

//                   var data= result;
//                  self.tableParams = new NgTableParams({}, { dataset: data });
//                },
//                error: function ServiceFailed(xhr, status, p3, p4) {
//                    var errMsg = status + " " + p3;
//                    errMsg = errMsg + "\n" + xhr.responseText;
//                    alert(errMsg);
//                    Showloading(false);
//                }
//            });
//            //var self = this;
//            //var data = [{ name: "Moroni", age: 50 } /*,*/];
//            //self.tableParams = new NgTableParams({}, { dataset: data });
//    }

//    //fecha fin mayor fecha inicio
//    $scope.dateEndGreaterThan = true;
//    //fecha inicio mayor fecha inicio
//    $scope.dateStartLessThan = true;
//    $scope.onChangeEndDate = function () {


//        var f1 = $.date_convert_ddmmyyy_to_iso($scope.startDate);
//        var f2 = $.date_convert_ddmmyyy_to_iso($scope.endDate);
//        if (f2 >= f1)
//        {
//            $scope.dateEndGreaterThan = true;
//        }
//        else
//        { $scope.dateEndGreaterThan = false; }

//        $scope.dateStartLessThan = true;
//    }
//    $scope.onChangeStartDate = function () {

//        var f1 = $.date_convert_ddmmyyy_to_iso($scope.startDate);
//        var f2 = $.date_convert_ddmmyyy_to_iso($scope.endDate);
//        if (f2 >= f1) {
//            $scope.dateStartLessThan = true;
//        }
//        else {
//            $scope.dateStartLessThan = false;
//        }

//        $scope.dateEndGreaterThan = true;
//    }
//});
