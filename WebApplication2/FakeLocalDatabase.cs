using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using TaskListApp.Lib.Data;
using WebApplication2.Helpers;

namespace WebApplication2
{
    public class FakeLocalDatabase:IDatabase
    {
        public List<DBUser> users;
        public List<DBTask> tasks;

        public string TestUser;

        public FakeLocalDatabase()
        {
            PopulateTasks();
            users = GetUsers();
            tasks = GetTasks();
        }

        public bool HasUsers()
        {
            return true;
        }


        public void PopulateTasks()
        {
            tasks = new List<DBTask>()
            {
                new DBTask()
                {
                    CreatedDate = DateTime.Now.AddDays(-10),
                    ModifiedDate = DateTime.Now.AddDays(-2),
                    Title = "A Great Task",
                    Description = "A Description of the task",
                    State = DBState.Active,
                    Id=0
                },
            new DBTask()
                {
                    CreatedDate = DateTime.Now.AddDays(-3),
                    ModifiedDate = DateTime.Now.AddDays(-1),
                    Title = "A Super Task",
                    Description = "A note of the task",
                    State = DBState.Archived,
                    Id=1
                },
                 new DBTask()
                {
                    CreatedDate = DateTime.Now.AddDays(-8),
                    ModifiedDate = DateTime.Now.AddDays(-4),
                    Title = "A Marvellous Task",
                    Description = "A summary of the task",
                    State = DBState.Completed,
                    Id=2
                }
            };
        }

        public void CreateUser(string username, string password)
        {
            users.Add(new DBUser()
            {
                Password = LoginHelper.EncodeAsSHA1(password),
                Username = username,
                Tasks = GetTasks()
            });
        }

        public List<DBUser> GetUsers()
        {
            users=new List<DBUser>();
            users.Add(new DBUser()
            {
                Password = LoginHelper.EncodeAsSHA1("password"),
                Username = "fakeuser1",
                Tasks = GetTasks()
            });
            users.Add(new DBUser()
            {
                Password = LoginHelper.EncodeAsSHA1("password"),
                Username = "validuser1",
                Tasks = GetTasks()
            });
            users.Add(new DBUser()
            {
                Password = LoginHelper.EncodeAsSHA1("password"),
                Username = "fakeuser2",
                Tasks=GetTasks()
            });
            return users;
        }

        public DBUser GetUser(string username)
        {
            return users.First(u => u.Username == username);
        }

        public bool AddUser(DBUser user)
        {

            users.Add(user);
            return true;
        }

        public bool AddUser(string username,string password)
        {
            var dbuser = new DBUser() {Username = username, Password = LoginHelper.EncodeAsSHA1(password)};
            users.Add(dbuser);
            return true;
        }

        public List<DBTask> GetTasks()
        {
            
            return tasks;
        }

        public List<DBTask> GetUserTasks(DBUser dbuser)
        {
            return tasks;
        }

        public bool SaveTask(DBTask dbtask, DBUser dbuser)
        {
            if (dbtask.Id == null)
            {
                var maxId = tasks.Max(t => t.Id);
                dbtask.Id = maxId + 2;

                tasks.Add(dbtask);
            }
            else
            {
                tasks.Remove(tasks.First(t => t.Id == dbtask.Id));
                tasks.Add(dbtask);

            }
            
            return true;
        }

        
        public DBTask GetTask(int id)
        {
           return tasks.First(t=>t.Id==id);
        }
    }
}