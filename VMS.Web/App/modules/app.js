var app = angular.module('taskWebApp', ['ngRoute', 'angular-loading-bar', 'LocalStorageModule', 'ngAnimate', 'mgcrea.ngStrap', 'ngResource', 'ngDialog', 'ui.grid', 'mgo-angular-wizard', 'angularFileUpload', 'angularGrid']);



var serviceBase = 'http://localhost:54834/';
app.constant('Settings', {
    apiServiceBaseUri: serviceBase
});


