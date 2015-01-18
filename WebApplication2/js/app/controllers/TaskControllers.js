taskApp.controller("TasksCtrl", function ($scope, TaskService) {
    $scope.alltasks = { length: 0 };

    $scope.$on('bcTasksUpdated', function (event, args) {
        $scope.counter = args.counter;
        $scope.alltasks = args.tasks;
    });
    $scope.reloadTasks = function () {
        TaskService.GetTasks()
        .then(function(resp) {
            $scope.$emit('emTasksUpdated', {counter:FunctionLib.resetTaskCounter(resp),tasks:resp});
        }, function (resp) {
            console.log("could not get tasks",resp);
        });
    };
   
   $scope.reloadTasks();
});

taskApp.controller("TaskCtrl", function ($scope,TaskService) {

    $scope.TaskStatusUpdate = function (newstatus, task) {
        task.State = newstatus;
        TaskService.UpdateTask(task)
            .then(function () {
                $scope.reloadTasks();
            }, function () {
                console.log("error");
            });
    };
    $scope.UpdateTask = function(task) {
        TaskService.UpdateTask(task)
            .then(function() {
                $scope.reloadTasks();
            }, function() {
                console.log("error");
            });
    };

    $scope.SaveTask = function (task,isValid) {
        if (isValid) {
            var tskNew = {
                Title: task.Title,
                Description: task.Description,
                State: 0,
                Id: null,
                CreatedDate: new Date(),
                ModifiedDate: new Date(),
            }
            TaskService.CreateTask(tskNew)
                .then(function() {
                    $scope.reloadTasks();
                });
        } else {
            $scope.$emit('emSubmissionError', { message: "Task Submission Failed" });
        }
    };

});