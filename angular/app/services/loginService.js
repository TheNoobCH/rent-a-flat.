angular.module('rent-a-flat')

    .factory('loginService', function ($http, $location, sessionService) {
        return {
            login: function(username, password, scope) {
                var loginJSON = '{ "username": "' + username + '", "password": "' + password + '" }';

                //var $promise = $http.post('http://localhost/RentAFlat/user/login', loginJSON);
                //$promise.then(function(msg) {
                //    if (msg.data.success) {
                //        var uid = msg.data.user;
                //        sessionService.set('RentAFlat_user', uid);
                //        $location.path("/home");
                //    } else {
                //        scope.errors = msg.data.text;
                //    }
                //
                //});

                sessionService.set('RentAFlat_user', 1);
                $location.path("/home");
            },

            logout: function() {
                sessionService.destroy('RentAFlat_user');
                $location.path("/home");
            },

            isLoggedIn: function () {
                return sessionService.get("RentAFlat_user");
            }
        }
    });