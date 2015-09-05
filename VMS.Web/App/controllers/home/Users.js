app.controller('home.Users',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout, $location) {
        //$scope.alert = alert;
        $scope.templates =
            [{ name: 'Landing Page', url: '/app/views/home/LandingPage.html' },
             { name: 'New Visitor', url: '/app/views/home/NewUser.html' },
            { name: 'New Visitor', url: '/app/views/home/login.html' }];

        $scope.template = $scope.templates[0];
        $scope.CheckIn = function () {
            $scope.template = $scope.templates[1];
        };

        $scope.go = function (path) {
            //$window.location.href = path;
            //$location.path(path);
            window.location = path;
        };

        $scope.finishedWizard = function () {
            
        }



    }
);

