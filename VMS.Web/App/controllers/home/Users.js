app.controller('home.Users',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout) {
        //$scope.alert = alert;
        $scope.templates =
            [{ name: 'Landing Page', url: '/app/views/home/LandingPage.html' },
             { name: 'New Visitor', url: '/app/views/home/NewUser.html' }];
        $scope.template = $scope.templates[0];
        $scope.CheckIn = function () {
            $scope.template = $scope.templates[1];
        };



        $scope.finishedWizard = function () {
            
        }



    }
);

