myApp.controller('homeController', ['$scope', '$rootScope', 'dataService', '$location', function ($scope, rootScope, dataService, $location) {
    $scope.isBusy = true;
    $scope.news = [];

    $scope.showText = function (article) {
        if (!article.showArticle) {
            article.showArticle = true;
        } else {
            article.showArticle = false;
        }
    }

    dataService.getData()
    .then(function (data) {
        angular.copy(data, $scope.news);
    },
        function () {
            //Handle error here
        })
    .then(function () {
        $scope.isBusy = false;
    });

    //$scope.$on('$locationChangeStart', function (event, newUrl, oldUrl) {
    //    var page = {}

    //    dataService.getPage(newUrl)
    //        .then(function (data) {

    //            if (data.PageType == 'StandardPage') {
    //                $location.path('foo');
    //            }
    //        },
    //        function () {
    //            //Handle error here
    //        })
    //        .then(function () {
    //            $scope.isBusy = false;
    //        });

    //});
}]);

//function Cntrl($scope, $location) {
//    $scope.changeView = function (view) {
//        $location.path(view); // path not hash
//    }
//}
