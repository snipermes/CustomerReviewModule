angular.module('customerReviewModule')
    .controller('customerReviewModule.helloWorldController', ['$scope', 'customerReviewModule.webApi', function ($scope, api) {
        var blade = $scope.blade;
        blade.title = 'CustomerReviewModule';

        blade.refresh = function () {
            api.get(function (data) {
                blade.title = 'customerReviewModule.blades.hello-world.title';
                blade.data = data.result;
                blade.isLoading = false;
            });
        };

        blade.refresh();
    }]);
