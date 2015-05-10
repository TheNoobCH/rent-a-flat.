angular.module('rent-a-flat')

    .controller('searchController', function ($scope, $location) {
        $scope.location = "";

        $scope.search = function () {
            $location.path("/listFlats/" + $scope.location);
        }
    });