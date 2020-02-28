var app = angular.module("app", ['ngRoute', 'toastr']);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/throwPoints", { controller: "throwPointsController", templateUrl: "app/views/throwPoints.html" })
        .when("/resultPoints", { controller: "resultPointsController", templateUrl: "app/views/resultPoints.html" })

});