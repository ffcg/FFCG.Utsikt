myApp.controller('standardPageController', ['$scope', 'dataService', function ($scope, dataService) {
    $scope.text = "Victory!";

    $scope.data = dataService.getLastObject();
}]);