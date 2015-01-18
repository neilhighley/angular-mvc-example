taskApp.controller("FooterCtrl", function ($scope) {
    $scope.$on('bcTasksUpdated', function (event, args) {
        $scope.counter = args.counter;
    });
    
});