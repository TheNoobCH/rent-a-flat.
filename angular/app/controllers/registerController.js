angular.module('rent-a-flat')

    .controller('registerController', function ($scope, $location) {

        $scope.username = "";
        $scope.password = "";
        $scope.passwordRep = "";
        $scope.email = "";
        $scope.firstname = "";
        $scope.lastname = "";
        $scope.errors = "";

        var isValid = true;


        var validate = function () {
            //clear messages!
            $scope.errors = "";
            isValid = true;

            //username
            if ($scope.username.length < 5) {
                $scope.errors += "<b>Username:</b> Must be at least 5 characters long.<br/>";
                isValid = false;
            } else if ($scope.username.length > 30) {
                $scope.errors += "<b>Username:</b> Mustn't be longer than 30 characters.<br/>";
                isValid = false;
            }


            //password
            if ($scope.password.length < 5) {
                $scope.errors += "<b>Password:</b> Must be at least 5 characters long.<br/>";
                isValid = false;
            } else if ($scope.password.length > 30) {
                $scope.errors += "<b>Password:</b> Mustn't be longer than 30 characters.<br/>";
                isValid = false;
            } else if (!$scope.password.match("[A-Z]")) {
                $scope.errors += "<b>Password:</b> Must have at least one Uppercase character. <br/>";
                isValid = false;
            } else if (!$scope.password.match("[a-z]")) {
                $scope.errors += "<b>Password:</b> Must have at least one Lowercase character. <br/>";
                isValid = false;
            } else if (!$scope.password.match("[0-9]")) {
                $scope.errors += "<b>Password:</b> Must have at least one number. <br/>";
                isValid = false;
            } else {
                var specialChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";
                var containsSpecialChars = false;
                for (var i = 0; i < $scope.password.length; i++) {
                    if (specialChars.indexOf($scope.password.charAt(i)) != -1) {
                        containsSpecialChars = true;
                    }
                }
                if (!containsSpecialChars) {
                    $scope.errors += "<b>Password:</b> Must have at least one special character. <br/>";
                    isValid = false;
                }
            }


            //password repetition
            if ($scope.password != $scope.passwordRep) {
                $scope.errors += "<b>Password repetition:</b> Must be identical with the Password. <br/>";
                isValid = false;
            }


            //email
            if ($scope.email.length < 5) {
                $scope.errors += "<b>Email:</b> Must have at least 5 Characters. <br/>";
                isValid = false;
            } else if ($scope.email.length > 60) {
                $scope.errors += "<b>Email:</b> Mustn't be longer than 60 characters. <br/>";
                isValid = false;
            }


            //firstname
            if ($scope.firstname.length < 5) {
                $scope.errors += "<b>Firstname:</b> Must have at least 5 Characters. <br/>";
                isValid = false;
            } else if ($scope.firstname.length > 30) {
                $scope.errors += "<b>Firstname:</b> Mustn't be longer than 30 characters. <br/>";
                isValid = false;
            } else if (!$scope.firstname.match("[A-z]")) {
                $scope.errors += "<b>Firstname:</b> Must contain only characters. <br/>";
                isValid = false;
            }


            //lastname
            if ($scope.lastname.length < 5) {
                $scope.errors += "<b>Lastname:</b> Must have at least 5 Characters. <br/>";
                isValid = false;
            } else if ($scope.lastname.length > 30) {
                $scope.errors += "<b>Lastname:</b> Mustn't be longer than 30 characters. <br/>";
                isValid = false;
            } else if (!$scope.lastname.match("[A-z]")) {
                $scope.errors += "<b>Lastname:</b> Must contain only characters. <br/>";
                isValid = false;
            }

            return isValid;
        };


        $scope.isValid = function() {
            return isValid;
        };

        $scope.register = function() {
            if (validate()) {
                console.log("register called without errors!");
            }
        };

        $scope.cancel = function() {
            $location.path('/home');
        };



    });