angular.module('rent-a-flat')

    .controller('newFlatController', function ($scope, $location) {

        $scope.postCode = "";
        $scope.address = "";
        $scope.location = "";
        $scope.title = "";
        $scope.price = "";
        $scope.roomCount = "";
        $scope.errors = "";


        $scope.save = function() {
            console.log("Save has been called!");

        };

        $scope.cancel = function() {
            $location.path('/home');
        };



    });