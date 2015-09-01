app.controller('admin.parking',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout) {
        $scope.templates =
            [{ name: 'New Parking', url: '/app/views/admin/ParkingAdd.html' },
             { name: 'Parking Master', url: '/app/views/admin/ParkingList.html' }];
        $scope.template = $scope.templates[0];
        $scope.ParkingMasterList = {};

        $scope.ParkingMasterList.columnDefs = [
          { name: 'TokenNo', displayName: 'Slot' },
          { name: '', displayName: 'Size' },
          { name: 'Name', displayName: 'Assigned To' },
          {
              name: 'Action',
              cellTemplate: '<button class="btn btn-primary label ">Edit</button>'
          }
        ];
        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/Checkedin?building=TCS').then(function (results) {
            $scope.ParkingMasterList.data = results.data;
        });


    }
);

