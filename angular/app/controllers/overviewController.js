angular.module('rent-a-flat')

    .controller('overviewController', function ($scope, $location, sessionService) {

        $scope.noFlats = "";
        $scope.noRentedFlats = "";
        $scope.noOffers = "";


        var myFlats = [{
            "id":  1,
            "title": "Mansion",
            "location": "Paris",
            "roomCount": 5,
            "price": 100
        }];

        var myRentedFlats = [];

        var myOffers = [{
            "flat": "Paris",
            "interest": "Luca Berger"
        }];

        $scope.navigateToNewFlat = function () {
            $location.path('/newFlat');
        };



        $scope.getMyFlats = function () {
            var userId = sessionService.get("RentAFlat_user");


            var flats = myFlats;
            if (flats.length == 0) {
                $scope.noFlats = "- You don't have inserted any flat!";
            }
            return flats;

        };

        $scope.getMyRentedFlats = function () {
            var userId = sessionService.get("RentAFlat_user");


            var flats = myRentedFlats;
            if (flats.length == 0) {
                $scope.noRentedFlats = "- You don't have rented any flat yet!";
            }
            return flats;
        };


        $scope.getMyOffers = function () {
            var userId = sessionService.get("RentAFlat_user");


            var offers = myOffers;
            if (offers.length == 0) {
                $scope.noOffers = "- You don't have any offers for your flats!";
            }
            return offers;
        };
    });