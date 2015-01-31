myApp.controller('linkController', ['$scope', 'dataService', '$location', function ($scope, dataService, $location) {
    $scope.text = "Victory!";

    //$scop.data = dataService.getLastObject();

    $scope.makeRequest = function(url) {
        dataService.getPage(url)
            .then(function (data) {
            
                if (data.PageType == 'StandardPage') {
                    $location.path(url);
                }
            },
            function () {
                //Handle error here
            })
            .then(function () {
                $scope.isBusy = false;
            });
    }



}]);