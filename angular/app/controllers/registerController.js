angular.module('rent-a-flat')

    .controller('registerController', function ($scope, $location) {

        $scope.username = "";
        $scope.password = "";
        $scope.passwordRep = "";
        $scope.email = "";
        $scope.firstname = "";
        $scope.lastname = "";

        $scope.register = function() {
            console.log("register called!");
        };

        $scope.cancel = function() {
            $location.path('/home');
        };



    });