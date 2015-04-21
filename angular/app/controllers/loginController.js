angular.module('rent-a-flat')

    .controller('loginController', function ($scope, $location, loginService) {

        $scope.username = "";
        $scope.password = "";
        $scope.errors = "";

        $scope.init = function () {
            setTimeout(function(){
                $('#modal-login').modal('show');
            }, 0);
        };

        $scope.isEnabled = function() {
            if ($scope.username != "" && $scope.password != "") {
                return true;
            }
            return false;
        };

        $scope.hide = function() {
            $('#modal-login').modal('hide');
            $location.path('/home');
        };

        $scope.login = function() {

            loginService.login($scope.username, $scope.password, $scope);
            //$scope.errors = "login pressed with credentials: " + $scope.username + " : " + $scope.password;

        };

        $scope.register = function() {
            $location.path('/register');
        };

    });