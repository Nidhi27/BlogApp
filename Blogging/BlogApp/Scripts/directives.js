﻿angular.module('app.directives', [])
    .directive('navigationbar', [function () {
        // Runs during compile
        return {
            // name: '',
            // priority: 1,
            // terminal: true,
            // scope: {}, // {} = isolate, true = child, false/undefined = no change
            controller: ['$scope', '$http', '$window', 'authService', function ($scope, $http, $window, authService) {
                $scope.authentication = authService.authentication;

                $scope.logOut = function () {
                    authService.logOut();
                  //  $scope.authenticated = authService.isAuth;
                    $window.location.href = "Index1.html";

                };
            }],

            //controller: ['$scope', '$http', function ($scope, $http) {
            //    $http.get('data/pages.json').success(function (data) {
            //        $scope.pages = data;
            //    });
            //}],
            // require: 'ngModel', // Array = multiple requires, ? = optional, ^ = check parent elements
            restrict: 'E', // E = Element, A = Attribute, C = Class, M = Comment
            // template: '',
            templateUrl: 'http://localhost:57649/BlogApp/partials/navigationbar.html',
            replace: true,
            // transclude: true,
            // compile: function(tElement, tAttrs, function transclude(function(scope, cloneLinkingFn){ return function linking(scope, elm, attrs){}})),
        };
    }]);;