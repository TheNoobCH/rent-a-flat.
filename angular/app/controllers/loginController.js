angular.module('rent-a-flat')

    .controller('loginController', function ($scope, $location) {

        $scope.username = "";
        $scope.password = "";

        $scope.init = function () {
            setTimeout(function(){
                $('#modal-login').modal('show');
            }, 0);
        };

        $scope.hide = function() {
            $('#modal-login').modal('hide');
            $location.path('/home');
        };

        $scope.login = function() {
            console.log("login pressed with credentials: " + $scope.username + " : " + $scope.password);
        };

        $scope.register = function() {
            $location.path('/register');
        };

        $scope.isEnabled = function() {
            if ($scope.username != "" && $scope.password != "") {
                return true;
            }
            return false;
        };



    });