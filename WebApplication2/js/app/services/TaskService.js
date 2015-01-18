
taskApp.factory('TaskService', function($http,$q) {
    return {
        Alive:1,
        GetTasks: function() {
            return $http.get('api/task')
                .then(function(response) {
                    var d = response.data;
                    this.Counter = FunctionLib.resetTaskCounter(d);
                    this.CurrentTasks = d;
                    return d;
                },
                    function(response) {
                        return $q.reject(response).data;
                    });
        },
        CreateTask : function(task){
            return $http.post('/api/task',task)
                .then(function() {
                    return;
                },
                function(response) {
                    //error
                    return $q.reject(response.data);
                });
        },
        UpdateTask : function( task) {
            return $http.put('api/task/' + task.Id, task)
                .then(function() {
                    return;
                },
                function(response) {
                    //error
                    return $q.reject(response.data);
                });
        },
        SaveTask: function (task) {
            return $http.put('api/task/' + task.Id, task)
                .then(function () {
                    return;
                },
                    function(response) {
                        return $q.reject(response.data);
                    });
        }
    }
});