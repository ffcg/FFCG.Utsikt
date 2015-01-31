myApp.controller('standardPageController', ['$scope', 'dataService', function ($scope, dataService) {
    $scope.text = "Victory!";
    $scope.data = "Loading data...";

    dataService.getLastObject()
        .then(function (data) {
                $scope.data = data;
            },
        function () {
            //Handle error here
        })
    .then(function () {
    });;
}]);