app.controller('mainCtrl',
    function ($scope, $modal, $animate, ngCrud, $http, ngDialog, myResource, $timeout) {
        $scope.OperType = 0;
        $scope.userId = "df9aaf79-d365-4119-8b26-2ae9ceca4e71";
        $('#page-wrapper').removeClass('nav-small');
    }
);

app.controller('taskCtrl',
    function ($scope, $modal, $animate, $q, ngCrud, myResource, ngDialog, $timeout) {
        $scope.selectedIndex = -1;
        $scope.userId = "df9aaf79-d365-4119-8b26-2ae9ceca4e71";
        
        $('#page-wrapper').removeClass('nav-small');



    }
);
