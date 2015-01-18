using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using TaskListApp.Lib.Data;
using WebApplication2.Helpers;

namespace WebApplication2
{
    /// <summary>
    /// Local Database class to pass the tasks to the entity model
    /// </summary>
    public class LocalDatabase:IDatabase
    {
        
        public LocalDatabase()
        {
            
        }

        public bool HasUsers()
        {
            using (var db = new Database1Entities1())
            {
                return db.Users.Any();
            }
        }

        public List<DBUser> GetUsers()
        {
            using (var db = new Database1Entities1())
            {
                if (db.Users.Any())
                {
                    List<DBUser> dbusers=new List<DBUser>();
                    foreach (var user in db.Users)
                    {
                        dbusers.Add(user.ToDBUser());
                    }
                    return dbusers;
                }
                else
                {
                    return null;
                }
                
            }
        }

        public DBUser GetUser(string username)
        {
            using (var db = new Database1Entities1())
            {
                try
                {
                    return db.Users.First(u => u.Username == username).ToDBUser();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public bool AddUser(DBUser user)
        {
            
           return AddUser(user.Username, user.Password);
            
        }

        public bool AddUser(string username,string password)
        {
            using (var db = new Database1Entities1())
            {
                if (db.Users.Count(u => u.Username == username) > 0) return false;

                var newUser = db.Users.Create();
                newUser.Username = username;
                newUser.Password = LoginHelper.EncodeAsSHA1(password);
                db.Users.Add(newUser);
                db.SaveChanges();
                return true;
            }
        }

        public List<DBTask> GetTasks()
        {
            using (var db = new Database1Entities1())
            {
                var tasks = db.Tasks;
                var tasksOut = new List<DBTask>();
                foreach (var task in tasks)
                {
                    tasksOut.Add(task.ToDBTask());
                }
                return tasksOut;
            }
        }

        public List<DBTask> GetUserTasks(DBUser dbuser)
        {
            if (dbuser == null) return null;
            using (var db = new Database1Entities1())
            {
                var user = db.Users.First(u=>u.Username==dbuser.Username);
                var tasks = user.Tasks;
                return tasks.Select(tsk => tsk.ToDBTask()).ToList();
            }
        }

        public bool SaveTask(DBTask dbtask, DBUser dbuser)
        {
            using (var db = new Database1Entities1())
            {
                var user = db.Users.First(u => u.Username == dbuser.Username);
                if (user.Tasks.Count(t => t.Id == dbtask.Id) > 0)
                {
                    //update
                    var task = db.Tasks.First(t => t.Id == dbtask.Id);
                    task.ModifiedDate = dbtask.ModifiedDate;
                    task.StateId = dbtask.State.ToStateId();
                }
                else
                {
                    //create
                    var task = db.Tasks.Create();
                    task.ModifiedDate = dbtask.ModifiedDate;
                    task.StateId = dbtask.State.ToStateId();
                    task.Description = dbtask.Description;
                    task.Title = dbtask.Title;
                    task.CreatedDate = dbtask.CreatedDate;
                    db.Tasks.Add(task);
                    db.SaveChanges();

                    user.Tasks.Add(task);//add to user tasks

                }
                db.SaveChanges();
            }
            return true;
        }

        
        public DBTask GetTask(int id)
        {
          using (var db = new Database1Entities1())
          {
              return db.Tasks.First(tsk => tsk.Id == id).ToDBTask();
          }
        }
    }

    public static class DBHelpers
    {
        public static short ToStateId(this DBState state)
        {
            if (state == DBState.Active) return 0;
            if (state == DBState.Completed) return 1;
            if (state == DBState.Archived) return 9;
            return 0;
        }
    }

}