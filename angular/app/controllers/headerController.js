angular.module('rent-a-flat')

    .controller('headerController', function ($scope, $location, sessionService, loginService, userService) {

        $scope.getUser = function() {
            return userService.getUser();
        };

        $scope.isLoggedIn = function() {
            return loginService.isLoggedIn();
        };

        $scope.logout = function() {
            sessionService.destroy("RentAFlat_user");
            $location.path("/home")
        }

    });