(function () {
    'use strict';

    angular.module('app').controller('PersonController', PersonController);

    PersonController.$inject = ['$scope', 'Restangular', 'ngTableParams'];

    function PersonController($scope, Restangular, ngTableParams) {
        /* jshint validthis:true */
        var vm = this;

        vm.search = '';
        
        vm.tableParams = new ngTableParams({
            page: 1,
            count: 10,
            sorting: {
                Name: 'asc'
            }
        },
        {
            getData: function ($defer, params) {
                // Load the data from the API
                Restangular.all('Person').getList({
                    pageNo: params.page(),
                    pageSize: params.count(),
                    sort: params.orderBy(),
                    search: vm.search
                }).then(function (persons) {
                    // Tell ngTable how many records we have (so it can set up paging)
                    params.total(persons.paging.totalRecordCount);

                    // Return the persons to ngTable
                    $defer.resolve(persons);
                }, function (response) {
                    // Notify of error
                });
            }
            
        });
    
        // Watch for changes to the search text, so we can reload the table
        $scope.$watch(angular.bind(vm, function () {
            return vm.search;
        }), function (value) {
            vm.tableParams.reload();
        });
        
    }
})();