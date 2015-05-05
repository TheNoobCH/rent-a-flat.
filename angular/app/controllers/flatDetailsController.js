angular.module('rent-a-flat')

    .controller('flatDetailsController', function ($scope) {

        $scope.flat = {
            "Id": 1,
            "OwnerId": 1,
            "OwnerDisplayName": "Felix Neidhart",
            "Location": "Bern",
            "PostCode": 3000,
            "Address": "L�nggassstrasse 43",
            "Title": "Mansion",
            "Price": 2000,
            "RoomCount": 5,
            "MainPic": "img/house_placeholder.png",
            "IsActive": true
        };

    });