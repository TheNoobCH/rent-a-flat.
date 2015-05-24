angular.module('rent-a-flat')

    .factory('flatService', function ($http) {
        return {
            getDetails: function(flatId) {
                var flatJSON = '{ "Id": ' + flatId + ' }';
                return $http.post('http://localhost/RentAFlat/Flat/Details', flatJSON);
            },

            getFlats: function (location) {
                var locationJSON = '{ "Location": "' + location + '" }';
                return $http.post('http://localhost/RentAFlat/Flat/IndexSearch', locationJSON);
            }
        }
    });