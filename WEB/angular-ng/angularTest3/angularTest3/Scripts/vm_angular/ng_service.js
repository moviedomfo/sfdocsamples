var myApp;
(function () {
         myApp = angular.module("myApp", []);
})();

myApp.service('dataService',function dataService($http, $q) {
    return {
        getAll: getAll
    }

    function getAll() {
        var defered = $q.defer();
        var promise = defered.promise;

        $http.get(httpHost + '/api/person/GetAll')
            .success(function (data) {
                defered.resolve(data);
            })
            .error(function (err) {
                defered.reject(err)
            });

        return promise;
    }
});

myApp.controller("personController",  function ($scope, dataService) {
    GetAllRecords();
    $scope.elementos = [];
    $scope.GetAllRecords = function () {
       
        GetAllRecords();
    }


    function GetAllRecords() {
        var promiseGet =  dataService.getAll();

        promiseGet.then(function(data) {
            $scope.elementos = JSON.stringify(data);
        }, function (errorPl) {
            $log.error('Some Error in Getting Records.', errorPl);
        });

    }
});
    