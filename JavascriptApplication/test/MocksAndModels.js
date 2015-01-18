var taskFactory= {
    UpdatedTaskObject: function() {
        return {
            Id: 1,
            State: 9,
            Title: "Update TITLE",
            Description: "Update Description"}
    },
    SaveTaskObject: function() {
        return {
            Id: Math.floor(Math.random()*999),
            State: 9,
            Title: "Update TITLE "+Math.floor(Math.random()*999),
            Description: "Update Description"}
    },
    DefaultTaskList:function(){
        return [
        { "Id": 1, "Title": "A Great Task", "Description": "A Description of the task", "CreatedDate": "2014-05-04T06:41:18.7551581+01:00", "ModifiedDate": "2014-05-12T06:41:18.7551581+01:00", "State": 0 },
        { "Id": 2, "Title": "A Super Task", "Description": "A note of the task", "CreatedDate": "2014-05-11T06:41:18.7551581+01:00", "ModifiedDate": "2014-05-13T06:41:18.7551581+01:00", "State": 9 },
        { "Id": 3, "Title": "A Marvellous Task", "Description": "A summary of the task", "CreatedDate": "2014-05-06T06:41:18.7551581+01:00", "ModifiedDate": "2014-05-10T06:41:18.7551581+01:00", "State": 1 }
        ]
    },
    CurrentTaskList: []
}

var mockFactory={
    createMock:function(type,args) {
        var mock = {};

        switch (type) {
            case "taskservice":
                q = args.q;
                deferredGet = args.deferred[0];
                deferredUpdate = args.deferred[1];
                deferredSave = args.deferred[2];
                deferredCreate = args.deferred[3];

                var argtasks = args.tasks;

                mock = {
                    tasks:argtasks,
                    GetTasks: function () {
                        deferredGet = q.defer();
                        deferredGet.resolve(this.tasks);
                        return deferredGet.promise;
                    },
                    UpdateTask: function (task) {
                        for (var i = 0; i < this.tasks.length; i++) {
                            if (this.tasks[i].Id == task.Id) {
                                this.tasks[i] = task;
                            }
                        }
                        deferredUpdate = q.defer();
                        deferredUpdate.resolve();
                        return deferredUpdate.promise;

                    },
                    SaveTask:function(task){
                        task.Id=Math.floor(Math.random()*999);
                        this.tasks.push(task);
                        deferredSave = q.defer();
                        deferredSave.resolve();
                        return deferredSave.promise;
                    },
                    CreateTask:function(task){
                        task.Id=Math.floor(Math.random()*999);
                        this.tasks.push(task);
                        deferredCreate = q.defer();
                        deferredCreate.resolve();
                        return deferredCreate.promise;
                    }
                };
                break;
        }

        return mock;
    },
    createStub:function(){
        return null;
    }

}