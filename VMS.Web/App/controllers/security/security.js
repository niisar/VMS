app.controller('security.security',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout, WizardHandler, toastr, mySharedService) {
        $scope.templates =
            [{ name: 'Visitors', url: '/app/views/security/list.html' },
             { name: 'New Visitor', url: '/app/views/security/add.html' }];
        $scope.template = $scope.templates[0];

        $scope.Checkout = function (ID) {
            //alert(ID);
            $http.post(Settings.apiServiceBaseUri + 'api/SecurityCheckin/CheckOut/'+ID).success(function (data) {
                toastr.success('User Checkedout succesfully', 'Checked Out');
                $scope.GetAllVisitors();
                $scope.GetCheckedIn();
                            }).error(function (data) {
                toastr.error('Error has occured', 'Error');
            });

        }

        $scope.CheckedIn = {
            columnDefs: [
                  { field: 'Name',headerName: 'Name', width: 150 },
                  { field: 'Vehicle', headerName: 'Vehicle', width: 200 },
                  { field: 'Building', headerName: 'Building', width: 120 },
                  { field: 'MeeTTo', headerName: 'Meet To', width: 150 },
                  { field: 'InTime', headerName: 'In Time', width: 120 },
                  { field: 'TokenNo', headerName: 'Token', width: 120 },
                  {
                      field: 'VisitorID',
                      headerName: 'Action',
                      width: 160 ,
                      template: '<button ng-click="Checkout(data.VisitorID)" class="btn btn-primary label">Checkout </button> '
                  }
            ],
            angularCompileRows: true,        };
        $scope.GetCheckedIn = function () {
            
            $http.get(Settings.apiServiceBaseUri + 'api/SecurityCheckin/SecurityChekedInVisitor').then(function (res) {
                //setTimeout(function () {
                $scope.CheckedIn.rowData = res.data;
                if ($scope.CheckedIn.api) {
                    $scope.CheckedIn.api.onNewRows();

                    $scope.CheckedIn.api.refreshView();
                }
                //    $scope.CheckedIn.api.onNewRows();
                //}, 2000);
              
                //$timeout(
                //    function kk() {
                //        $scope.tabs.activeTab = 1;
                //    }
                //    , 1000);
                //$timeout(
                //  function kk() {
                //      $scope.tabs.activeTab = 0;
                //  }
                //  , 1000);
                            });
        }
        $scope.GetCheckedIn();
        

        $scope.AllVisitors = {
            columnDefs: [
               { field: 'Name', headerName: 'Name', width: 240 },
               { field: 'Vehicle', headerName: 'Vehicle', width: 200 },
               { field: 'Building', headerName: 'Building', width: 120 },
               { field: 'MeeTTo', headerName: 'Meet To', width: 240 },
               { field: 'InTime', headerName: 'In Time', width: 120 },
               { field: 'OutTime', headerName: 'Out Time', width: 120 },
                  { field: 'Status', headerName: 'Token', width: 220 },

            ],
        };
        $scope.GetAllVisitors = function () {
            $http.get(Settings.apiServiceBaseUri + 'api/SecurityCheckin/SecurityAllVisitor').then(function (res) {
                $scope.AllVisitors.rowData = res.data;
                if ($scope.AllVisitors.api) {
                    $scope.AllVisitors.api.onNewRows();
                }
            });
        }
        $scope.GetAllVisitors();
        
        $scope.AllVisitors.ready = function () {
            $scope.AllVisitors.api.onNewRows();
        };
        $scope.CheckedIn.ready = function () {
            $scope.CheckedIn.api.onNewRows();
            $scope.CheckedIn.api.refreshView();
        };
       


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
        $scope.$on('handleBroadcast', function () {
            $scope.VisitorDetails.VisitorPic = mySharedService.message;
        });

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
            $scope.VisitorDetails.VisitorPic = "";
            //$scope.VisitorDetails.Status = "";
        }
        $scope.finishedWizard = function () {
            $http.post(Settings.apiServiceBaseUri + 'api/Visitors/Post', this.VisitorDetails).success(function (data) {
                toastr.success('SMS sent succesfully to <strong>' + $scope.VisitorDetails.MeeTTo + '</strong> at <strong>' + $scope.VisitorDetails.SmsNo + '</strong>', 'SMS Sent');
                $scope.resetForm();
                WizardHandler.wizard().goTo(0);
                $scope.GetCheckedIn();
            }).error(function (data) {
                toastr.error('Error has occured', 'Error');
            });
            
       

            // DOMO: Uncomment this for demmo
            // toastr.success('SMS sent succesfully to <strong>' + $scope.VisitorDetails.MeeTTo + '</strong> at <strong>' + $scope.VisitorDetails.SmsNo + '</strong>', 'SMS Sent');
        }



        


    }
);

