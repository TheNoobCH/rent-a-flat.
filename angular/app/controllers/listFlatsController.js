angular.module('rent-a-flat')

    .controller('listFlatsController', function ($scope,$location,$routeParams, flatService) {

        var counter = 0;
        $scope.flats = [];
        $scope.message = "";

        var getFlats = function () {
            if (counter < 1) {
                flatService.getFlats($routeParams.location).then(function (data) {
                    console.error(data);
                    console.log(data.data);
                    $scope.flats = data.data;
                    if (data.data.length == 0) {
                        $scope.message = "No flats were found at this location!";
                    }

                }, function (err) {
                    $scope.flats = [];
                    $scope.message = "An error occured by trying to connect!";
                });
                counter++;
            }
            $scope.flats = [];
        };



        $scope.flatSelected = function(Id){
            //$location.path("/flatDetails").search({flatId: Id});
            $location.path("/flatDetails/" + Id);
        };

        $scope.getUser = function() {
            //return userService.getUser();
        };

        getFlats();

    });