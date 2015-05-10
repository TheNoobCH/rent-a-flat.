angular.module('rent-a-flat')

    .controller('listFlatsController', function ($scope,$location,$routeParams, flatService) {

         var flats = [{
            "Id": 1,
            "OwnerId": 1,
            "OwnerDisplayName": "Felix Neidhart",
            "Location": "Bern",
            "PostCode": 3000,
            "Address": "Länggassstrasse 43",
            "Title": "Mansion",
            "Price": 2000,
            "RoomCount": 5,
            "MainPic": "img/klsjf.jpg",
            "IsActive": true
        },{
            "Id": 2,
            "OwnerId": 3,
            "OwnerDisplayName": "Luca Berger",
            "Location": "Bern",
            "PostCode": 3000,
            "Address": "Muristalden 43",
            "Title": "Haus",
            "Price": 2500,
            "RoomCount": 6,
            "MainPic": "img/dlsjf.jpg",
            "IsActive": true
        }];

        $scope.getFlats = function () {
            //if ($routeParams.location == undefined || $routeParams.location == "") {
            //    console.log("ListFlats --> called with a location!");
            //    return flats;
            //} else {
            //    console.log("ListFlats --> called with a location!");
            //    return flats;
            //}

            flatService.getFlats($routeParams.location).then(function (data) {
                console.error(data);
                return data;
            }, function (err) {

            });

        };

        $scope.flatSelected = function(Id){
            //$location.path("/flatDetails").search({flatId: Id});
            $location.path("/flatDetails/" + Id);
        };

        $scope.getUser = function() {
            //return userService.getUser();
        };

    });