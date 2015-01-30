var myApp = angular.module('epiApp', []);

myApp.controller('homeController', ['$scope', function ($scope) {
    $scope.data = "Epi!";
}]);