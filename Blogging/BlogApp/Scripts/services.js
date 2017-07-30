angular.module('app.services', [])

    .factory('PostService', function ($http) {
        var fac = {};
        fac.GetAllRecords = function () {
            return $http.get('http://localhost:57649/api/post/');
        }

        fac.GetAllRecordsByCategory = function (categoryId) {
            return $http.get('http://localhost:57649/api/post/?categoryId=' + categoryId);
        }

        return fac;
    })


    .factory('CategoryService', function ($http) {
        var fac = {};
        fac.GetAllRecords = function () {
            return $http.get('http://localhost:57649/api/category/');
        }
        return fac;
    })

    .factory('TagService', function ($http) {
        var fac = {};
        fac.GetAllRecords = function () {
            return $http.get('http://localhost:57649/api/tag/');
        }
        return fac;
    })

    .factory('RegistrationService', function ($http) {
        var registrationServiceFactory = {};

        registrationServiceFactory.saveRegistration = function (registration) {
            return $http.post('http://localhost:57649/api/account/register', registration)
        }

        return registrationServiceFactory;

    })

    .factory('authInterceptorService', ['$q', '$injector', '$window', 'localStorageService', function ($q, $injector, $window, localStorageService) {

        var authInterceptorServiceFactory = {};

        authInterceptorServiceFactory.request = function (config) {

            config.headers = config.headers || {};

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }

            return config;
        }

        authInterceptorServiceFactory.responseError = function (rejection) {
            if (rejection.status === 401) {

                var authService = $injector.get('authService');
                var authData = localStorageService.get('authorizationData');
                //authService.logOut();

            }
            return $q.reject(rejection);
        };

        return authInterceptorServiceFactory;

    }])


    .factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {

        var serviceBase = '/';

        var authServiceFactory = {};

        var _authentication = {
            isAuth: false,
            userName: "",
            isAdmin: false
        };

        var _saveRegistration = function (registration) {

            _logOut();

            return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
                return response;
            });
        };

        var _login = function (loginData) {

            var data = "grant_type=password&username=" +
                loginData.userName + "&password=" + loginData.password;

            var deferred = $q.defer();

            $http.post(serviceBase + 'token', data, {
                headers:
                { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {

                localStorageService.set('authorizationData',
                    { token: response.access_token, userName: loginData.userName });

                _authentication.isAuth = true;
                _authentication.userName = loginData.userName;
                if (loginData.userName == "nidhi@gmail.com")
                {
                    _authentication.isAdmin = true;
                }
                deferred.resolve(response);

            }).catch(function (err, status) {
                _logOut();
                deferred.reject(err);
            });

            return deferred.promise;
        };

        var _logOut = function () {

            localStorageService.remove('authorizationData');

            _authentication.isAuth = false;
            _authentication.userName = "";
            _authentication.isAdmin = false;
        };

        var _fillAuthData = function () {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
                if (authData.userName == "nidhi@gmail.com") {
                    _authentication.isAdmin = true;
                }
            }
        }

        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentication = _authentication;

        return authServiceFactory;
    }]);




