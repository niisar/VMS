app.controller('lobby.lobby',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout) {
        $scope.templates =
            [{ name: 'TCS', url: '/app/views/security/list.html' },
             { name: 'New Visitor', url: '/app/views/security/add.html' }];
        $scope.template = $scope.templates[0];
        $scope.CheckedIn = {};

        $scope.CheckedIn.columnDefs = [
          { name: 'Name' },
          { name: 'Building' },
          { name: 'MeeTTo', displayName: 'Meet To' },
          { name: 'InTime', displayName: 'In Time' },
          { name: 'TokenNo', displayName: 'Token' },
          {
              name: 'Action',
              cellTemplate: '<button class="btn btn-primary label ">CheckIn</button>&nbsp;<button class="btn btn-primary label" readonly="readonly">Checkout</button>'
          }
        ];
        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/Checkedin?building=TCS').then(function (results) {
            $scope.CheckedIn.data = results.data;
        });

        $scope.AllVisitors = {};
        $scope.AllVisitors.columnDefs = [
            { name: 'Name' },
            { name: 'Vehicle' },
            { name: 'Building' },
            { name: 'MeeTTo', displayName: 'Meet To' },
            { name: 'InTime', displayName: 'In Time' },
            { name: 'OutTime' },
            { name: 'TokenNo', displayName: 'Token' },
            { name: 'EntryDate', displayName: 'Date', width: 100 },

            
            { name: 'Status', displayName: 'Status' },
        ];
        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/AllVisitors').then(function (results) {
            $scope.AllVisitors.data = results.data;
        })

        $scope.MyVisitors = {};
        $scope.MyVisitors.columnDefs = [
            { name: 'Name' },
            { name: 'Vehicle' },
            { name: 'Building' },
            { name: 'MeeTTo', displayName: 'Meet To' },
            { name: 'InTime', displayName: 'In Time' },
            { name: 'OutTime' },
            { name: 'TokenNo', displayName: 'Token' },
        ];
        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/MyVisitors?building=TCS').then(function (results) {
            $scope.MyVisitors.data = results.data;
        })



        $scope.tabs = [
            { title: '0', name: 'Visitors', template: '/app/views/lobby/CheckedIn.html', content: "sd" },
          { title: '1', name: 'My Visitors', template: '/app/views/lobby/MyVisitors.html', content: "sd" },
          { title: '2', name: 'All Visitors', template: '/app/views//lobby/AllVisitors.html', content: "sd" },


        ];

        $scope.finishedWizard = function () {
            alert('finished');
        }

    }
);

