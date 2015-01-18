'use strict'


var mockTaskService={};

describe("ControllerTests (1)",function(){
    beforeEach(module("taskApp"));
    var q, scope;
    var deferredGet,deferredSave,deferredUpdate,deferredCreate;
    var taskCtrlUnderTest;
    var tasksCtrlUnderTest;
    var currentTasks=taskFactory.DefaultTaskList();

    beforeEach(inject(function($rootScope,$q){
        deferredGet={};
        deferredSave={};
        deferredUpdate={};
        deferredCreate={};
        q=$q;
        scope=$rootScope.$new();
        mockTaskService=mockFactory.createMock("taskservice",{q:q,deferred:[deferredGet,deferredUpdate,deferredSave,deferredCreate],tasks:currentTasks});


        spyOn(mockTaskService,'GetTasks').andCallThrough();
        spyOn(mockTaskService,'UpdateTask').andCallThrough();
    }));

    //Inject fake factory into controller
    beforeEach(inject(function ($controller) {
        taskCtrlUnderTest=$controller('TaskCtrl',{$scope:scope,TaskService:mockTaskService});
        tasksCtrlUnderTest=$controller('TasksCtrl',{$scope:scope,TaskService:mockTaskService});
    }));

    describe("TaskController Tests",function(){
        it("should call getTasks on start",function(){
            scope.$apply();
            expect(mockTaskService.GetTasks).toHaveBeenCalled();
        })
        it("should have an update function",function(){
            scope.$apply();
            expect(angular.isFunction(scope.TaskStatusUpdate)).toBe(true);
        })
        it("should have call the update function of the task service",function(){
            scope.$apply();
            scope.UpdateTask(0,taskFactory.UpdatedTaskObject());
            expect(mockTaskService.UpdateTask).toHaveBeenCalled();
        })
        it("should update the task",function(){
            scope.$apply();
            scope.UpdateTask(taskFactory.UpdatedTaskObject());
            expect(currentTasks[0].State).toBe(9);
        });
        it("should update the task state",function(){
            scope.$apply();
            scope.TaskStatusUpdate(999,currentTasks[0]);
            expect(currentTasks[0].State).toBe(999);
        });

        it("should add the task",function(){
            scope.$apply();
            currentTasks=taskFactory.DefaultTaskList();//reset tasks to default
            expect(currentTasks.length).toBe(3);
            var nt=taskFactory.SaveTaskObject();
            nt.Id=0;
            scope.SaveTask(nt,true);
            expect(currentTasks.length).toBe(4);
            expect(currentTasks[currentTasks.length-1].Id).toNotBe(0);

        });


    });

    describe("TasksControllerTest",function(){

    });

    describe("MovieBannerControllerTest",function(){

    });

    describe("FooterControllerTest",function(){

    });


});

/*
//broadcast tests
 var rootScope;
 beforeEach(inject(function($injector) {
 rootScope = $injector.get('$rootScope');
 spyOn(rootScope, '$broadcast');
 }));

 describe("my tests", function() {
 it("should broadcast something", function() {
 expect(rootScope.$broadcast).toHaveBeenCalledWith('myEvent');
 });
 });
 */