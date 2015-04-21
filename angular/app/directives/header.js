angular.module('rent-a-flat')

	.directive('rentAFlatHeader', function() {
		return {
			restrict: 'E',
            controller: 'headerController',
			templateUrl: 'views/header.html'
		};
	});