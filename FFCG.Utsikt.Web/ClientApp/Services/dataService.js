(function () {
    angular
        .module('services')
        .factory('dataService', dataService);

    dataService.$inject = ['$q', '$http'];

    function dataService($q, $http) {
        var _service = {}

        _service.getData = function () {
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
})();