using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Lib.Data;

namespace WebApplication2
{
    public static class ModelExtensions
    {
        public static Models.Task ToModelTask(this DBTask dbtask)
        {
            return new Models.Task()
            {
                CreatedDate = dbtask.CreatedDate,
                ModifiedDate = dbtask.ModifiedDate,
                Description = dbtask.Description,
                State = dbtask.State.ToModelState(),
                Title = dbtask.Title,
                Id=dbtask.Id
            };
        }

        public static Models.User ToModelUser(this DBUser dbuser)
        {
            var mu = new Models.User()
            {
                Password = dbuser.Password,
                UserName = dbuser.Username,
                Tasks = dbuser.Tasks.Select(t => t.ToModelTask()).ToList()
            };
            return mu;
        }
        public static int ToModelState(this DBState state)
        {
            if (state == DBState.Active) return 0;
            if (state == DBState.Completed) return 1;
            if (state == DBState.Archived) return 9;
            return 0;
        }
    }
}