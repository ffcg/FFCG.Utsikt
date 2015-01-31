var myApp = angular.module('epiApp', ['ngRoute']);

myApp.config(['$routeProvider',
    '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $routeProvider.when('/standard-page', {
            controller: 'standardPageController',
            templateUrl: 'PartialViews/standard.html'
        });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }]);

angular.module("epiApp").value("episerversidedata", {});
