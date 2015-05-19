angular.module('rent-a-flat')

    .controller('flatDetailsController', function ($scope, flatService, $routeParams) {

        $scope.message = "";

        $scope.getFlat = function () {

            if ($routeParams.flatId == undefined || $routeParams.flatId == "") {
                $scope.message = "Something went wrong!";
            } else {
                flatService.getDetails($routeParams.flatId).then(function (data) {
                    if (data.data.error != undefined && !data.data.error) {
                        return data.data;
                    } else {
                        $scope.message = "The server detected an error";
                    }

                }, function () {
                    $scope.message = "Could not receive data from server!";
                });
            }
        };

    });