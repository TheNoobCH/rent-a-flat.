angular.module('rent-a-flat')

    .controller('flatDetailsController', function ($scope, flatService, $routeParams) {

        $scope.message = "";

        var flat = {
            "Id": 1,
            "OwnerId": 1,
            "OwnerDisplayName": "Felix Neidhart",
            "Location": "Bern",
            "PostCode": 3000,
            "Address": "Länggassstrasse 43",
            "Title": "Mansion",
            "Price": 2000,
            "RoomCount": 5,
            "MainPic": "img/house_placeholder.png",
            "IsActive": true
        };

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