using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using TaskListApp.Lib.Data;

namespace WebApplication2.Controllers
{
    public class TaskController : ApiController
    {
        private IDatabase db;

        public string forceUser
        {
            get; 
            set;
        }

        public TaskController()
        {
            db = new LocalDatabase();
        }
        public TaskController(IDatabase database)
        {
            db = database;
        }
        
        // GET api/task
        /// <summary>
        /// Returns all tasks
        /// </summary>
        /// <returns></returns>
        public List<Models.Task> Get()
        {
            var username = forceUser??User.Identity.Name;


            var tasks = new List<Models.Task>();
            if (username == "") return tasks;

            var user = db.GetUser(username);

            var dbtasks = db.GetUserTasks(user);

            foreach (var task in dbtasks)
            {
                tasks.Add(task.ToModelTask());
            }

            return tasks;

        }

        // GET api/task/5
        public Models.Task Get(int id)
        {
            return db.GetTask(id).ToModelTask();
        }

        // POST api/task
        public void Post([FromBody]Models.Task task)
        {
            //add new Task
            var username = forceUser ?? User.Identity.Name;
            task.CreatedDate = DateTime.Now;
            task.ModifiedDate = DateTime.Now;

            var user = db.GetUser(username);
            db.SaveTask(task.ToDBTask(),user);

        }

        // PUT api/task/5
        public void Put(int id, [FromBody]Models.Task task)
        {
            var username = forceUser ?? User.Identity.Name;
            task.Id = id;
            task.CreatedDate = DateTime.Now;
            task.ModifiedDate = DateTime.Now;

            var user = db.GetUser(username);
            var dbtask = task.ToDBTask();
            db.SaveTask(dbtask, user);
        }

    }
}
