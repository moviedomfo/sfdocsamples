//var app = angular.module('myApp', ['ngGrid']);
var app;
(function () {
    app = angular.module("myApp", ['ngGrid']);
})();
app.service('EmployeeService', function ($http) {

    this.getAllEmployee = function () {
        return $http.get(httpHost + "/home/GetAll");
    }
});

app.controller('MyCtrl', function ($scope, EmployeeService) {

    $scope.myData = [];
    //$scope.myData = [{ Name: "Moroni", DocNumber: 50 },
    //                 { Name: "Tiancum", DocNumber: 43 },
    //                 { Name: "Jacob", DocNumber: 27 },
    //                 { Name: "Nephi", DocNumber: 29 },
    //                 { Name: "Enos", DocNumber: 34 }];

    GetAllRecords();
    function GetAllRecords() {
        var promiseGet = EmployeeService.getAllEmployee();
        promiseGet.then(function (pl) { $scope.Employees = pl.data, $scope.Data = pl.data },
              function (errorPl) {
                  $log.error('Some Error in Getting Records.', errorPl);
              });
    }
    //$scope.gridOptions = { data: 'myData' };
    $scope.gridOptions = {
        data: 'myData',
        enablePaging: true,
        showFooter: true,
        totalServerItems: 'totalServerItems',
        pagingOptions: $scope.pagingOptions,
        filterOptions: $scope.filterOptions
    };

    $scope.filterOptions = {
        filterText: "",
        useExternalFilter: true
    };
    $scope.totalServerItems = 0;
    $scope.pagingOptions = {
        pageSizes: [5, 10, 20],
        pageSize: 5,
        currentPage: 1
    };
    $scope.setPagingData = function (data, page, pageSize) {
        var pagedData = data.slice((page - 1) * pageSize, page * pageSize);
        $scope.myData = pagedData;
        $scope.totalServerItems = data.length;
        if (!$scope.$$phase) {
            $scope.$apply();
        }
    };

    $scope.getPagedDataAsync = function (pageSize, page, searchText) {
        setTimeout(function () {
            var data;
            if (searchText) {
                var ft = searchText.toLowerCase();
                $.ajax({
                    type: 'POST',
                    url: httpHost + '/home/GetAll',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(varData),
                    success: function (result) {

                        var data = JSON.stringify(result);
                        $scope.setPagingData(data, page, pageSize);
                       
                    },
                    error: function ServiceFailed(xhr, status, p3, p4) {
                        var errMsg = status + " " + p3;
                        errMsg = errMsg + "\n" + xhr.responseText;
                        alert(errMsg);
                        Showloading(false);
                    }
                });

            //    $http.get('jsonFiles/largeLoad.json').success(function (largeLoad) {
            //        data = largeLoad.filter(function (item) {
            //            return JSON.stringify(item).toLowerCase().indexOf(ft) != -1;
            //        });
            //        $scope.setPagingData(data, page, pageSize);
            //    });
            //} else {
            //    $http.get('jsonFiles/largeLoad.json').success(function (largeLoad) {
            //        $scope.setPagingData(largeLoad, page, pageSize);
            //    });
            }
        }, 100);
    };

    $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage);

    $scope.$watch('pagingOptions', function (newVal, oldVal) {
        if (newVal !== oldVal && newVal.currentPage !== oldVal.currentPage) {
            $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
        }
    }, true);
    $scope.$watch('filterOptions', function (newVal, oldVal) {
        if (newVal !== oldVal) {
            $scope.getPagedDataAsync($scope.pagingOptions.pageSize, $scope.pagingOptions.currentPage, $scope.filterOptions.filterText);
        }
    }, true);
  
    $scope.search = function () {
        
            alert('search');
                var varData = {
                   
                }
                $.ajax({
                    type: 'POST',
                    url: httpHost + '/home/GetAll',
                    dataType: 'json',
                    contentType: "application/json;charset=utf-8",
                    data: JSON.stringify(varData),
                    success: function (result) {
                
                        $scope.myData = JSON.stringify(result);
                        $scope.setPagingData(largeLoad, page, pageSize);
                       $scope.$apply();
                    },
                    error: function ServiceFailed(xhr, status, p3, p4) {
                        var errMsg = status + " " + p3;
                        errMsg = errMsg + "\n" + xhr.responseText;
                        alert(errMsg);
                        Showloading(false);
                    }
                });
              
        }
});

