app.controller('lobby.lobby',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout) {
        $scope.templates =
            [{ name: 'TCS', url: '/app/views/security/list.html' },
             { name: 'New Visitor', url: '/app/views/security/add.html' }];
        $scope.template = $scope.templates[0];
        $scope.CheckedIn = {
            columnDefs: [
                  { field: 'Name', headerName: 'Name' },
                  { field: 'Building', headerName: 'Building' },
                  { field: 'MeeTTo', headerName: 'Meet To' },
                  { field: 'InTime', headerName: 'In Time' },
                  { field: 'TokenNo', headerName: 'Token' },
                  {
                      field: 'Action',
                      headerName: 'Action',
                      template: '<button class="btn btn-primary label ">CheckIn</button>&nbsp;<button class="btn btn-primary label" readonly="readonly">Checkout</button>'
                  }
            ],
        };


        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/Checkedin?building=TCS').success(function (data) {
            $scope.CheckedIn.rowData = data;
        });



        $scope.AllVisitors = {
            columnDefs : [
            { field: 'Name' ,headerName:'Name'},
            { field: 'Vehicle',headerName:'Vehicle' },
            { field: 'Building',headerName:'Building' },
            { field: 'MeeTTo', headerName: 'Meet To' },
            { field: 'InTime', headerName: 'In Time' },
            { field: 'OutTime', headerName :'Out Time'},
            { field: 'TokenNo', headerName: 'Token' },
            { field: 'EntryDate', headerName: 'Date', width: 100 },


            { field: 'Status', displayName: 'Status' },
            ],
        };
        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/AllVisitors').success(function (data) {
            $scope.AllVisitors.rowData = data;
        })

        $scope.MyVisitors = {
            columnDefs : [
             { field: 'Name', headerName: 'Name' },
            { field: 'Vehicle', headerName: 'Vehicle' },
            { field: 'Building', headerName: 'Building' },
            { field: 'MeeTTo', displayName: 'Meet To' },
            { field: 'InTime', displayName: 'In Time' },
            { field: 'OutTime', headerName: 'Out Time' },
            { field: 'TokenNo', displayName: 'Token' },
            ],
        };
        
        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/MyVisitors?building=TCS').success(function (data) {
            $scope.MyVisitors.rowData = data;
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

