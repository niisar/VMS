app.controller('security.security',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout, WizardHandler, toastr) {
        $scope.templates =
            [{ name: 'Visitors', url: '/app/views/security/list.html' },
             { name: 'New Visitor', url: '/app/views/security/add.html' }];
        $scope.template = $scope.templates[0];

        $scope.Checkout = function (ID) {
            alert(ID);
            //$location.path('/common/Registration');
        }

        $scope.CheckedIn = {
            columnDefs: [
                  { field: 'Name', headerName: 'Name',width: 150 },
                  { field: 'Vehicle', headerName: 'Vehicle', width: 200 },
                  { field: 'Building', headerName: 'Building', width: 120 },
                  { field: 'MeeTTo', headerName: 'Meet To', width: 150 },
                  { field: 'InTime', headerName: 'In Time', width: 120 },
                  { field: 'TokenNo', headerName: 'Token', width: 120 },
                  {
                      field: 'ID',
                      headerName: 'Action',
                      width: 160 ,
                      template: '<button ng-click="Checkout(1)" class="btn btn-primary label">Checkout </button> '
                  }
            ],
            
        };
        $http.get(Settings.apiServiceBaseUri + 'api/SecurityCheckin/SecurityChekedInVisitor').success(function (data) {
            $scope.CheckedIn.rowData = data;
        });

        

        $scope.AllVisitors = {
            columnDefs: [
               { field: 'Name', headerName: 'Name', width: 240 },
               { field: 'Vehicle', headerName: 'Vehicle', width: 200 },
               { field: 'Building', headerName: 'Building', width: 120 },
               { field: 'MeeTTo', headerName: 'Meet To', width: 240 },
               { field: 'InTime', headerName: 'In Time', width: 120 },
               { field: 'OutTime', headerName: 'Out Time', width: 120 },
            ],
        };

        $http.get(Settings.apiServiceBaseUri + 'api/SecurityCheckin/SecurityAllVisitor').success(function (data) {
            $scope.AllVisitors.rowData = data;
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
        $scope.VisitorDetails.SmsNo = "9939673732";
        $scope.resetForm = function () {
            $scope.VisitorDetails.Name = "";
            $scope.VisitorDetails.Guests = "";
            $scope.VisitorDetails.Email = "";
            $scope.VisitorDetails.Phone = "";
            $scope.VisitorDetails.IdCard = "";
            $scope.VisitorDetails.Vehicle = "";
            $scope.VisitorDetails.VehicleNu = "";
            $scope.VisitorDetails.Color = "";
            $scope.VisitorDetails.ParkineZone = "";
            $scope.VisitorDetails.Building = "";
            $scope.VisitorDetails.MeeTTo = "";
            $scope.VisitorDetails.InTime = "";
            $scope.VisitorDetails.SmsNo = "";
            //$scope.VisitorDetails.Status = "";
        }
        $scope.finishedWizard = function () {
            //$http.post(Settings.apiServiceBaseUri + 'api/Visitors/Post', this.VisitorDetails).then(function (results) {
            //    $scope.resetForm();
            //    WizardHandler.wizard().goTo(0);
            //});
            
       

            //ngDialog.open({
            //    template: '/App/views/tpl/smsSent.html',
            //    scope: $scope
            //});
            toastr.success('SMS sent succesfully to <strong>' + $scope.VisitorDetails.MeeTTo + '</strong> at <strong>' + $scope.VisitorDetails.SmsNo + '</strong>', 'SMS Sent');
        }



        


    }
);

