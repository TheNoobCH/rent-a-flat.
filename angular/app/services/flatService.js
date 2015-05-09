angular.module('rent-a-flat')

    .factory('flatService', function ($http) {
        return {
            getDetails: function(flatId) {
                var flatJSON = '{ "Id": ' + flatId + ' }';
                return $http.post('http://localhost/RentAFlat/Flat/Details', flatJSON);
            }
        }
    });