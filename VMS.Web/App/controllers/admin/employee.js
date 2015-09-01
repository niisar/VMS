app.controller('admin.employee',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout) {
        $scope.templates =
            [{ name: 'Employee Master', url: '/app/views/admin/EmployeeImport.html' },
             { name: 'Parking Master', url: '/app/views/admin/ParkingList.html' }];
        $scope.template = $scope.templates[0];
        $scope.empList = {};

        $scope.empList.columnDefs = [
          { name: 'kks', displayName: 'Name' },
          { name: 'kksd', displayName: 'Gender' },
          { name: 'kak', displayName: 'Age' },
          { name: 'kaaak', displayName: 'DOB' },
          { name: 'kk', displayName: 'Department' }
        ];
        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/Checkedin?building=TCS').then(function (results) {
            $scope.empList.data = results.data;
        });


    }
);

