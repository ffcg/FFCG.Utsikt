myApp.factory('dataService', ['$q', '$http', '$location', 
    function ($q, $http, $location) {
        var _service = {}

        var _dataObject = {}

        _service.getData = function () {
            var deferred = $q.defer();

            $http.get('http://ffcg.utsikt.local/newsfeed')
                .then(function (result) {
                    deferred.resolve(result.data);
                }, function () {
                    deferred.reject();
                });

            return deferred.promise;
        }

        _service.getPage = function(url) {
            var deferred = $q.defer();

            $http.get('http://ffcg.utsikt.local/pageasjson/?PageUrl=' + url)
                .then(function (result) {
                    deferred.resolve(result.data);
                _dataObject = result.data;
            }, function () {
                    deferred.reject();
                });

            return deferred.promise;
        }

        _service.getLastObject = function () {
            var deferred = $q.defer();

            if (_dataObject.PageName != null) {
                deferred.resolve(_dataObject);
            } else {
                return _service.getPage($location.path());
            }

            return deferred.promise;
            //if (_dataObject === undefined || _dataObject == null) {
            //    _service.getPage($location.path);
            //}
            //return _dataObject;
        }

        return _service;
    }
]);