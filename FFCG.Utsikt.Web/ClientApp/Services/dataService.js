myApp.factory('dataService', ['$q', '$http',
    function ($q, $http) {
        var _service = {}

        var _dataObject = {}

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

        _service.getPage = function(url) {
            var deferred = $q.defer();

            $http.get('pageasjson/' + url)
                .then(function (result) {
                    deferred.resolve(result.data);
                _dataObject = result.data;
            }, function () {
                    deferred.reject();
                });

            return deferred.promise;
        }

        _service.getLastObject = function() {
            return _dataObject;
        }

        return _service;
    }
]);