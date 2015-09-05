app.controller('admin.employee',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout, $upload) {
        $scope.templates =
            [{ name: 'Employee Master', url: '/app/views/admin/EmployeeImport.html' },
             { name: 'Parking Master', url: '/app/views/admin/ParkingList.html' }];
        $scope.template = $scope.templates[0];
        $scope.empList = {};

        $scope.empList.columnDefs = [
          { name: 'Name', displayName: 'Name' },
          { name: 'Gender', displayName: 'Gender' },
          { name: 'Age', displayName: 'Age' },
          { name: 'DOB', displayName: 'DOB' },
          { name: 'Department', displayName: 'Department' }
        ];
        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/Checkedin?building=TCS').then(function (results) {
            $scope.empList.data = results.data;
        });



        $scope.upload = [];
        $scope.fileUploadObj = { testString1: "Test string 1", testString2: "Test string 2" };

        $scope.onFileSelect = function ($files) {
            //$files: an array of files selected, each file has name, size, and type.
            for (var i = 0; i < $files.length; i++) {
                var $file = $files[i];
                (function (index) {
                    $scope.upload[index] = $upload.upload({
                        url: Settings.apiServiceBaseUri + "api/Import/upload", // webapi url
                        method: "POST",
                        //data: { fileUploadObj: $scope.fileUploadObj },
                        file: $file
                    }).progress(function (evt) {
                        // get upload percentage
                        console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
                    }).success(function (data, status, headers, config) {
                        // file is uploaded successfully
                        console.log(data);
                        $scope.empList.data = data.kk;
                    }).error(function (data, status, headers, config) {
                        // file failed to upload
                        console.log(data);
                    });
                })(i);
            }
        }

        $scope.abortUpload = function (index) {
            $scope.upload[index].abort();
        }

    }
);

