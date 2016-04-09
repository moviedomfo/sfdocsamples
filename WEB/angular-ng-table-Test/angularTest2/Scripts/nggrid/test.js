var app;
(function () {
    app = angular.module("myApp", ['ngGrid']);
})();
app.service('EmployeeService', function ($http) {

    this.getAllEmployee = function () {
        return $http.get(httpHost + "/api/person/GetAll");
    }

});

app.controller('EmployeeController', function ($scope, EmployeeService) {

    GetAllRecords();
    function GetAllRecords() {
        var promiseGet = EmployeeService.getAllEmployee();
        promiseGet.then(function (pl) { $scope.Employees = pl.data, $scope.myData = pl.data },
              function (errorPl) {
                  $log.error('Some Error in Getting Records.', errorPl);
              });
    }
    $scope.LastName;
    $scope.Name;
    $scope.myData = [];
    $scope.gridOptions = {

        data: 'myData',
        pagingOptions: $scope.pagingOptions,
        enablePinning: true,
        enablePaging: true,
        showFooter: true,
        enableColumnResize: true,
        enableCellSelection: true,
        columnDefs: [
                {
                    field: "Name",
                    width: 180,
                    pinned: true,
                    enableCellEdit: true
                },
                {
                    field: "PersonId",
                    width: 200,
                    enableCellEdit: true
                },
                {
                    field: "Lastname",
                    width: 100,
                    enableCellEdit: true
                },
                {
                    field: "docNumber",
                    width: 120,
                    enableCellEdit: true,
                    cellTemplate: basicCellTemplate
                },
                {
                    field: "Action",
                    width: 200,
                    enableCellEdit: false,
                    cellTemplate: '<button id="editBtn" type="button" class="btn btn-xs btn-info"  ng-click="updateCell()" >Edit </button>'
                }]

    };

    $scope.selectedCell;
    $scope.selectedRow;
    $scope.selectedColumn;

    $scope.filterOptions = {
        filterText: "",
        useExternalFilter: true
    };
    $scope.editCell = function (row, cell, column) {
        $scope.selectedCell = cell;
        $scope.selectedRow = row;
        $scope.selectedColumn = column;
    };

    $scope.gridOptions.sortInfo = {
        fields: ['Lastname', 'docNumber'],
        directions: ['asc'],
        columns: [0, 1]
    };
    $scope.totalServerItems = 0;

    $scope.pagingOptions = {
        pageSizes: [5, 10, 20],
        pageSize: 5,
        currentPage: 1
    };
    var basicCellTemplate = '<div class="ngCellText" ng-class="col.colIndex()" ng-click="editCell(row.entity, row.getProperty(col.field), col.field)"><span class="ui-disableSelection hover">{{row.getProperty(col.field)}}</span></div>';


    $scope.changeGroupBy = function (group1, group2) {
        $scope.gridOptions.$gridScope.configGroups = [];
        $scope.gridOptions.$gridScope.configGroups.push(group1);
        $scope.gridOptions.$gridScope.configGroups.push(group2);
        $scope.gridOptions.groupBy();
    }
    $scope.clearGroupBy = function () {
        $scope.gridOptions.$gridScope.configGroups = [];
        $scope.gridOptions.groupBy();
    }

    $scope.submit = function () {

        alert("Quiere insertar " +   $scope.LastName + " " +  $scope.Name);
    }
    $scope.dataToSjon;
    $scope.showBindedData = function () {

        alert(JSON.stringify( $scope.myData));
    }
    $scope.refresh = function () {
 
        var promiseGet = EmployeeService.getAllEmployee();
        promiseGet.then(
              function (pl) { $scope.Employees = pl.data, $scope.myData = pl.data },
              function (errorPl) {
                  $log.error('Ocurrio un error al llamar el servicio.', errorPl);
              }
              );
    }
});
