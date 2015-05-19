angular.module('rent-a-flat')

    .config(function ($routeProvider) {

        $routeProvider
            .when("/home", {templateUrl: "views/search.html", controller: "searchController"})
            .when("/login", {templateUrl: "views/login.html", controller: "loginController"})
            .when("/register", {templateUrl: "views/register.html", controller: "registerController"})
            .when("/overview", {templateUrl: "views/overview.html", controller: "overviewController"})
            .when("/listFlats/:location", {templateUrl: "views/listFlats.html", controller: "listFlatsController"})
            .when("/flatDetails/:flatId", {templateUrl: "views/flatDetails.html", controller: "flatDetailsController"})
            .when("/newFlat", {templateUrl: "views/newFlat.html", controller: "newFlatController"})
            .otherwise({redirectTo: '/home'});

    });