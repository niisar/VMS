app.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {
    var serviceBase = 'http://localhost:57749/';

    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: ""
    };

    // Register users
    var _saveRegistration = function (registration) {
        _logOut();
        return $http.post(serviceBase + 'api/account/register', registration).then(function (response) { return response; });
    };

    // Login user
    var _login = function (loginData) {
       
        var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

        var deferred = $q.defer();
        $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(
            function (response) {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName });
                _authentication.isAuth = true;
                _authentication.userName = loginData.userName;
                deferred.resolve(response);
            }).error(
            function (data, status, headers, config) {
                console.log(data.error_description);
               

                _logOut();
                deferred.reject(data);
            });
        return deferred.promise;
    };

    // logout user
    var _logOut = function () {
        localStorageService.remove('authorizationData');
        _authentication.isAuth = false;
        _authentication.userName = "";
    };

    // get auth data
    var _fillAuthData = function () {
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }
    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;
}]);