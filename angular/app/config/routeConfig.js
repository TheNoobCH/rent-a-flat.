angular.module('rent-a-flat')

    .config(function ($routeProvider, $locationProvider) {

        //$locationProvider.html5Mode(true);

        $routeProvider
            .when("/home", {templateUrl: "views/search.html"})
            .when("/login", {templateUrl: "views/login.html"})
            .when("/register", {templateUrl: "views/register.html"})
            .otherwise({redirectTo: '/home'});


    });