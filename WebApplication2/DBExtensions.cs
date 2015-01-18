using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskListApp.Lib.Data;

namespace WebApplication2
{
    public static class DBExtensions
    {

        public static DBUser ToDBUser(this WebApplication2.User user)
        {
            return new DBUser()
            {
                Password = user.Password,
                Username = user.Username,
                Tasks = user.Tasks.Select(t => t.ToDBTask()).ToList()
            };
        }
        public static DBUser ToDBUser(this WebApplication2.Models.User user)
        {
            return new DBUser()
            {
                Password = user.Password,
                Username = user.UserName,
                Tasks = user.Tasks.Select(t => t.ToDBTask()).ToList()
            };
        }

         public static DBTask ToDBTask(this WebApplication2.Task task)
         {
             var dbtask= new DBTask()
             {
                 CreatedDate = task.CreatedDate,
                 ModifiedDate = task.ModifiedDate,
                 Description = task.Description,
                 State = task.StateId.ToDBState(),
                 Title = task.Title
             };
             if (task.Id != null)
             {
                 dbtask.Id = task.Id;
             }
             return dbtask;
         }
         public static DBTask ToDBTask(this WebApplication2.Models.Task task)
         {
             var dbtask= new DBTask()
             {
                 CreatedDate = task.CreatedDate,
                 ModifiedDate = task.ModifiedDate,
                 Description = task.Description,
                 State = task.State.ToDBState(),
                 Title=task.Title
             };
             if (task.Id != null)
             {
                 dbtask.Id = task.Id;
             }
             return dbtask;
         }

         public static DBState ToDBState(this short state)
         {
             switch (state)
             {
                 default:
                     return DBState.Active;
                 case 1:
                     return DBState.Completed;
                 case 9:
                     return DBState.Archived;
             }
         }
         public static DBState ToDBState(this int state)
         {
             switch (state)
             {
                 default:
                     return DBState.Active;
                 case 1:
                     return DBState.Completed;
                 case 9:
                     return DBState.Archived;
             }
         }
    }
}