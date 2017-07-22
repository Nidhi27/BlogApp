angular.module('app', ['ngRoute','app.controllers','app.services'])
    .config(['$routeProvider', function ($routeProvider) {

        $routeProvider.when('/', {
            templateUrl: 'http://localhost:57649/BlogApp/Views/post.html',
            controller: 'PostController'
        })
            .when('/post/:Id', {
                templateUrl: 'http://localhost:57649/BlogApp/Views/singlePost.html',
                controller: 'SinglePostController'
            })

          
            .when('/create', {
                templateUrl: 'http://localhost:57649/BlogApp/Views/create.html',
                controller: 'PostController'
            })

            .when('/manageCategory', {
                templateUrl: 'http://localhost:57649/BlogApp/Views/manageCategory.html',
                controller: 'CategoryController'
            })

            .when('/managePosts', {
                templateUrl: 'http://localhost:57649/BlogApp/Views/managePosts.html',
                controller: 'PostController'
            })
            .when('/manageTag', {
                templateUrl: 'http://localhost:57649/BlogApp/Views/manageTag.html',
                controller: 'TagController'
            })

            .when('/registration', {
                templateUrl: 'http://localhost:57649/BlogApp/Views/registration.html',
                controller: 'registrationController'
            })

            .when('/login', {
                templateUrl: 'http://localhost:57649/BlogApp/Views/login.html',
                controller: 'LoginController'
                
            })

         .otherwise({
             redirectTo: '/'
        });
    }]);
