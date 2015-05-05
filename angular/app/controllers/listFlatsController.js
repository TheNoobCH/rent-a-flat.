angular.module('rent-a-flat')

    .controller('listFlatsController', function ($scope,$location,$routeParams) {

        //public
        $scope.flats = [{
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

        $scope.flatSelected = function(Id){
            //$location.path("/flatDetails").search({flatId: Id});
            $location.path("/flatDetails/flatId=" + Id);
        };

        $scope.getUser = function() {
            //return userService.getUser();
        };

        // private
        var message = "Test";

        var getUser = function() {
          return message;
        };

        //Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT(1,1),
        //OwnerId INT NOT NULL,
        //Location NVARCHAR(32) NOT NULL,
        //PostCode TINYINT NOT NULL,
        //Address NVARCHAR(64) NOT NULL,
        //Title NVARCHAR(32) NOT NULL,
        //Price REAL NOT NULL,
        //RoomCount Decimal(2,1) NOT NULL,
        //MainPic NVARCHAR(128) NOT NULL,
        //IsActive BIT NOT NULL,
        //Location NVARCHAR(32) NOT NULL,

    });