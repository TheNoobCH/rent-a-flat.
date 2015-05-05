angular.module('rent-a-flat')

    .factory('loginService', function ($http, $location, sessionService) {
        return {
            login: function(username, password, scope) {
                var loginJSON = '{ "Username": "' + username + '", "Password": "' + password + '" }';

                var $promise = $http.post('http://localhost/RentAFlat/Authentication/Login', loginJSON);
                $promise.then(function(msg) {
                    console.error(msg.data);
                    if (msg.data.authenticated) {
                        var uid = msg.data.userId;
                        sessionService.set('RentAFlat_user', uid);
                        $location.path("/home");
                    } else {
                        scope.errors = msg.data.text;
                    }
                }, function () {
                    scope.errors = "Could not send data to server!"
                });
            },

            logout: function() {
                sessionService.destroy('RentAFlat_user');
                $location.path("/home");
            },

            isLoggedIn: function () {
                return sessionService.get("RentAFlat_user");
            },

            register: function (username, password, firstname, lastname, email, scope) {
                var registerJSON = '{ "Username": "' + username + '", "Password": "' + password + '", "Firstname": "' + firstname + '", "Lastname": "' + lastname + '", "Email": "' + email + '", "IsActive": 1}';

                var $promise = $http.post('http://localhost/RentAFlat/User/Register', registerJSON);
                $promise.then(function(msg) {
                    console.error(msg.data);
                    if (msg.data.success) {
                        $location.path("/home");
                    } else {
                        scope.errors = msg.data.text;
                    }
                }, function () {
                    scope.errors = "Could not send data to server!"
                });
            }
        }
    });