angular.module('rent-a-flat')

    .factory('userService', function ($http, sessionService) {
        return {
            getUser: function() {

                var user = {};
                var id = sessionService.get("RentAFlat_user");
                if (id != null) {
                    var json = '{ "id": "' + id + '" }';

                    //var $promise = $http.post('http://localhost/RentAFlat/user/details', json);
                    //$promise.then(function(msg) {
                    //    if (msg.data.success) {
                    //        user = msg.data.user;
                    //    }
                    //
                    //});

                    user = {
                        "firstname": "Luca",
                        "lastname": "Berger",
                        "username": "luca10",
                        "email": "kucki10@hotmail.com"
                    };
                }

                return user;
            }
        }
    });