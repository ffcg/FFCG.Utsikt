var myApp = angular.module('epiApp', []);

myApp.controller('homeController', ['$scope', 'dataService', function ($scope, dataService) {

    $scope.news = [];

    dataService.getData()
    .then(function (data) {
        angular.copy(data, $scope.news);
    },
        function () {
            //Handle error here
        })
    .then(function () {
        //Afterwards
    });
}]);

myApp.factory('dataService', ['$q', '$http',
    function ($q, $http) {
        var _service = {}

        _service.getData = function() {
            var deferred = $q.defer();

            $http.get('newsfeed')
                .then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

            return deferred.promise;
        }

        return _service;
    }
]);