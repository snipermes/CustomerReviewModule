angular.module('customerReviewModule')
    .factory('customerReviewModule.webApi', ['$resource', function ($resource) {
        return $resource('api/CustomerReviewModule');
}]);
