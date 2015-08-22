app.factory('authInterceptorService', ['$q', '$location', 'localStorageService',
function ($q, $location, localStorageService) {
    var authInterceptorServiceFactoy = {};
    var _request = function (config) {
        config.headers = config.headers || {};
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }
        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            location.href = '/common/login';

        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactoy.request = _request;
    authInterceptorServiceFactoy.responseError = _responseError;

    return authInterceptorServiceFactoy;
}]);