app.config(function ($modalProvider) {
    angular.extend($modalProvider.defaults, {
        animation: 'am-fade-and-scale',
        keyboard: true
    });
})
app.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeBar = true;
    cfpLoadingBarProvider.includeSpinner = false
    cfpLoadingBarProvider.latencyThreshold = 100;
}]);

app.config(['$routeProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when("/", {
        redirectTo: '/security/desk'
    });

 


    $routeProvider.when("/security/desk", {
        templateUrl: "/app/views/security/desk.html",
        controller: "security.security",
        title: 'My Desk'
    });

    $routeProvider.when("/lobby/Desk", {
        templateUrl: "/app/views/lobby/Desk.html",
        controller: "lobby.lobby",
        title: 'My Desk'
    });

    $routeProvider.when("/camera/capture", {
        templateUrl: "/app/views/camera/capture.html",
        controller: "camera.capture",
        title: 'Capture'
    });
    

    $routeProvider.when("/common/error_404", {
        templateUrl: "/app/views/common/Error_404.html",
        controller: "taskCtrl",
        title: 'Error 404'
    });

    $routeProvider.when("/login", {
        templateUrl: "/app/views/auth/login_",
        controller: "loginController",
        title: 'Login'
    });


    $routeProvider.otherwise({
        redirectTo: '/common/Error-404'
    });


    // use the HTML5 History API
    //$locationProvider.html5Mode(true);
    //$locationProvider.hashPrefix('!');
}]);


app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
    //$httpProvider.defaults.useXDomain = true;
    //delete $httpProvider.defaults.headers.common['X-Requested-With'];
    //delete $httpProvider.defaults.headers.post['Content-type'];
});


var serviceBase = "http://localhost:57749/";
app.constant(['ngAuthSettings', function (authService) {
    apiServiceBaseUri: serviceBase
}]);

app.run(['$location', '$rootScope', 'authService', function ($location, $rootScope, authService) {
    $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
        $rootScope.title = current.$$route.title;
    });
}]);
