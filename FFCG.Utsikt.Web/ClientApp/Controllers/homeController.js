myApp.controller('homeController', ['$scope', 'dataService', function ($scope, dataService) {
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
}]);