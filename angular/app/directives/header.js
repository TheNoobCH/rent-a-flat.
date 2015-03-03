angular.module('rent-a-flat')

	.directive('rentAFlatHeader', function() {
		return {
			restrict: 'E',
			templateUrl: 'views/header.html'
		};
	});