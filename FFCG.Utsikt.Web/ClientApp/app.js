var myApp = angular.module('epiApp', ['ngRoute']);


//ClientApp
myApp.config(['$routeProvider',
    '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $routeProvider.when('/standard-page', {
            controller: 'standardPageController',
            templateUrl: 'http://ffcg.utsikt.local/PartialViews/standard.html'
        }).otherwise({
            controller: 'standardPageController',
            templateUrl: 'http://ffcg.utsikt.local/PartialViews/standard.html'
        });

        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }]);

angular.module("epiApp").value("episerversidedata", {});
