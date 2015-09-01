app.controller('admin.meeting',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout) {
        $scope.templates =
            [{ name: 'New Meeting', url: '/app/views/admin/MeetingAdd.html' },
             { name: 'Meeting List', url: '/app/views/admin/MeetingList.html' }];
        $scope.template = $scope.templates[0];
        $scope.meetingList = {};

        $scope.meetingList.columnDefs = [
           { name: 'kks', displayName: 'Event' },
          { name: 'kksd', displayName: 'Location' },
          { name: 'kak', displayName: 'Attendees' },
          { name: 'kaaak', displayName: 'Date' },
          { name: 'kk', displayName: 'Duration' },
          { name: 'kk1', displayName: 'Reminder' },
          { name: 'kk2', displayName: 'Repeat' }
         
        ];
        $http.get(Settings.apiServiceBaseUri + 'api/LobbyCheckin/Checkedin?building=TCS').then(function (results) {
            $scope.meetingList.data = results.data;
        });


    }
);

