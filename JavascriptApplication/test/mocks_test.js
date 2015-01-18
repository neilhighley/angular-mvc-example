describe("Test Preparation testing",function() {
    describe("Mock Service Functionality Test", function () {
        it("should have all methods for Taskservice in mock", function () {
            expect(angular.isFunction(mockTaskService.GetTasks)).toBe(true);
            expect(angular.isFunction(mockTaskService.UpdateTask)).toBe(true);
            expect(angular.isFunction(mockTaskService.CreateTask)).toBe(true);
            expect(angular.isFunction(mockTaskService.SaveTask)).toBe(true);
        });
    });
    describe("Task Factory should be functional for tests", function () {
        it("should return 3 tasks", function () {
            expect(taskFactory.CurrentTaskList().length).toBe(3);
        });
        it("should return a single task for update object", function () {
            expect(taskFactory.UpdatedTaskObject().Id).toEqual(1);
            expect(taskFactory.UpdatedTaskObject().Title).toEqual("Update TITLE");
            expect(taskFactory.UpdatedTaskObject().Description).toEqual("Update Description");


        });
        it("should have a save task", function(){
            expect(angular.isObject(taskFactory.SaveTaskObject())).toEqual(true);

        });
    });
});