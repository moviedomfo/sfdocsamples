var myApp;
(function () {
         myApp = angular.module("myApp", []);
})();


    
    myApp.controller("personController", ['$scope', '$q', function ($scope, $q) {
        $scope.sumarUno = function (numero) {
            var q = $q.defer();
            $scope.step++;
            if (angular.isNumber(numero)) {
                q.resolve(numero + 1);
            }
            else {
                q.reject("no es numero");
            }
            return q.promise;
        }

        $scope.step = 0;
        $scope.myValue = 0;
        $scope.promise = $scope.sumarUno($scope.myValue);

        $scope.promise.then(
            function (v) { return $scope.sumarUno(v) },
            function (v) { return $scope.sumarUno(v) }
            )
        .then(function (v) { return $scope.myValue = v+3 },
            function (err) { return $scope.myValue = err }
            );
    }]);
    