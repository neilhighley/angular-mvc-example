var taskCounter = {};
var taskApp = angular.module("taskApp", ['ui.bootstrap']);
var FunctionLib = new FunctionLib();

//set up broadcaster
taskApp.run(function ($rootScope) {
    $rootScope.$on('emTasksUpdated', function (event, args) {
        $rootScope.$broadcast('bcTasksUpdated', args);
    });
});

