angular.module('rent-a-flat')

    .controller('listFlatsController', function ($scope) {

        //public
        $scope.message = "Test";

        $scope.getUser = function() {
            //return userService.getUser();
        };

        // private
        var message = "Test";

        var getUser = function() {
          return message;
        };

    });