angular.module('rent-a-flat')

	.directive('rentAFlatFooter', function() {
		return {
			restrict: 'E',
			templateUrl: 'views/footer.html'
		};
	});