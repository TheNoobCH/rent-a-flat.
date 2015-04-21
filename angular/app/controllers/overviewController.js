angular.module('rent-a-flat')

    .controller('overviewController', function ($scope, $location) {

        $scope.myFlats = [{
            "id":  1,
            "flat": "Paris"
        }];

        $scope.myRentedFlats = [];

        $scope.myOffers = [{
            "flat": "Paris",
            "interest": "Luca Berger"
        }];

    });