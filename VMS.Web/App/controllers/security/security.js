app.controller('security.security',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout) {
        $scope.templates =
            [{ name: 'Visitors', url: '/app/views/security/list.html' },
             { name: 'New Visitor', url: '/app/views/security/add.html' }];
        $scope.template = $scope.templates[0];

        $scope.Checkout = function (ID) {
            alert(ID);
            //$location.path('/common/Registration');
        }


        $scope.CheckedIn = {};
        $scope.CheckedIn.columnDefs = [
          { name: 'Name' },
          { name: 'Vehicle' },
          { name: 'Building' },
          { name: 'MeeTTo', displayName: 'Meet To' },
          { name: 'InTime', displayName: 'In Time' },
          { name: 'TokenNo', displayName: 'Token' },
          {
              field:'ID',
              displayName: 'Action',
              cellTemplate: '<button ng-click="Checkout(1)" class="btn btn-primary label">Checkout </button> '
          }
        ];

        $http.get(Settings.apiServiceBaseUri + 'api/SecurityCheckin/SecurityChekedInVisitor').then(function (results) {
            $scope.CheckedIn.data = results.data;
        });

        $scope.AllVisitors = {};
        $scope.AllVisitors.columnDefs = [
          { name: 'Name' },
          { name: 'Vehicle' },
          { name: 'Building' },
          { name: 'MeeTTo', displayName: 'Meet To' },
          { name: 'InTime' },
          { name: 'OutTime' },
        ];

        $http.get(Settings.apiServiceBaseUri + 'api/SecurityCheckin/SecurityAllVisitor').then(function (results) {
            $scope.AllVisitors.data = results.data;
        });



        $scope.tabs = [
            { title: '0', name: 'Checked In', template: '/app/views/security/CheckedIn.html', content: "Empty Data" },
          { title: '1', name: 'All Visitors', template: '/app/views/security/AllVisitors.html', content: "Empty Data" },

        ];

        // get formated date in js 
        //var today = new Date();
        //var dd = today.getDate();
        //var mm = today.getMonth() + 1; //January is 0!

        //var yyyy = today.getFullYear();
        //if (dd < 10) {
        //    dd = '0' + dd
        //}
        //if (mm < 10) {
        //    mm = '0' + mm
        //}
        $scope.VisitorDetails = {};
        $scope.finishedWizard = function () {
            //var Visitor = {};
            //Visitor.Name = $scope.VisitorDetails.Name;
            //Visitor.Email = $scope.VisitorDetails.Email;
            //Visitor.Phone = $scope.VisitorDetails.Phone;
            //Visitor.IdCard = $scope.VisitorDetails.IdCard;
            //Visitor.Vehicle = $scope.VisitorDetails.Vehicle;
            //Visitor.VehicleNu = $scope.VisitorDetails.VehicleNu;
            //Visitor.Color = $scope.VisitorDetails.Color;
            //Visitor.ParkineZone = $scope.VisitorDetails.ParkineZone;
            //Visitor.Building = $scope.VisitorDetails.Building;
            //Visitor.MeeTTo = $scope.VisitorDetails.MeeTTo;
            //Visitor.InTime = $scope.VisitorDetails.InTime;
            //Visitor.OutTime = $scope.VisitorDetails.OutTime;
            //Visitor.TokenNo = $scope.VisitorDetails.TokenNo;
            //Visitor.Status = $scope.VisitorDetails.Status;
            //Visitor.EntryDate = today;

            $http.post(Settings.apiServiceBaseUri + 'api/Visitors/Post', $scope.VisitorDetails).then(function (results) {
                
            });
            //$http.get(Settings.apiServiceBaseUri + 'api/Visitors/Get').then(function (results) {

            //});
        }
    }
);

