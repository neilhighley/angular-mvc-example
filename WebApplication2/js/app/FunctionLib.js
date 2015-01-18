function FunctionLib() {
    function countItemsInState(state, items) {
        var tot = 0;
        if (items == undefined) return 0;//not loaded yet
        for (var i = 0; i < items.length; i++) {
            var task = items[i];
            if (task.State == state) tot++;
        }
        return tot;
    }
    this.resetTaskCounter = function (data) {
        var taskCounter = { active: 0, completed: 0, archived: 0, all: 0 };
        taskCounter.active = countItemsInState(0, data);
        taskCounter.all = data.length;
        taskCounter.completed = countItemsInState(1, data);
        taskCounter.archived = countItemsInState(9, data);
        return taskCounter;
    }
}