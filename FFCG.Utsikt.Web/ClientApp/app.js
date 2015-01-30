var myApp = angular.module('epiApp', ['ngRoute']);

myApp.config(['$routeProvider',
    '$locationProvider',
    function ($routeProvider, $locationProvider) {
        $routeProvider.when('/foo', {
            controller: 'standardPageController',
            templateUrl: 'PartialViews/standard.html'
        });

        //$locationProvider.html5Mode(true);
    }]);
