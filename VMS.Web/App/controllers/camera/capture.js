app.controller('camera.capture',
    function ($scope, $modal, Settings, $animate, ngCrud, $http, ngDialog, myResource, $timeout) {
        // Grab elements, create settings, etc.
        var canvas = document.getElementById("canvas"),
           context = canvas.getContext("2d"),
           video = document.getElementById("video"),
           videoObj = { "video": true },
           errBack = function (error) {
               console.log("Video capture error: ", error.code);
           };

        // Put video listeners into place
        var localStream;
        if (navigator.getUserMedia) { // Standard
            navigator.getUserMedia(videoObj, function (stream) {
                video.src = stream;
                localStream = stream;
                video.play();
            }, errBack);
        } else if (navigator.webkitGetUserMedia) { // WebKit-prefixed
            navigator.webkitGetUserMedia(videoObj, function (stream) {
                video.src = window.webkitURL.createObjectURL(stream);
                localStream = stream;
                video.play();
            }, errBack);
        } else if (navigator.mozGetUserMedia) { // WebKit-prefixed
            navigator.mozGetUserMedia(videoObj, function (stream) {
                video.src = window.URL.createObjectURL(stream);
                localStream = stream;
                video.play();
            }, errBack);
        }

        //TODO:  remove variable as it already declared on top above
        var canvas = document.getElementById("canvas");
       
        var data;
        // Trigger photo take
        document.getElementById("snap").addEventListener("click", function () {
            

            context.drawImage(video, 0, 0, 160, 120);
            //var win = window.open();
            //win.document.write("<img src='" + document.getElementById("canvas").toDataURL() + "'/>");
             data = JSON.stringify(
                                {
                                    value: canvas.toDataURL().replace('data:image/png;base64,', '')

                                });
             //$http({
             //    method: 'POST',
             //    url: '/api/Camera',
             //    data: data
            //})
             localStream.stop();
        });

        document.getElementById("btnSave").addEventListener("click", function () {
            console.log(data);
            $http({
                method: 'POST',
                url: '/api/Camera',
                data: data
            })
        });

    }
);

