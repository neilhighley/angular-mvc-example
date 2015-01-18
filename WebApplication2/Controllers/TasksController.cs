
using System.Collections.Generic;
using System.Web.Http;
using TaskListApp.Lib.Data;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class TasksController : ApiController
    {
        private IDatabase db;
        
        public TasksController()
        {
            db = new LocalDatabase();
        }
        public TasksController(IDatabase dbDatabase)
        {
            db = dbDatabase;
        }
        
        public List<Models.Task> Get()
        {
            var username = User.Identity.Name;

            
            var tasks = new List<Models.Task>();
            if (username == "") return tasks;

            var user = db.GetUser(username);

            var dbtasks = db.GetUserTasks(user);
            if (dbtasks != null)
            {
                foreach (var task in dbtasks)
                {
                    tasks.Add(task.ToModelTask());
                }
            }
            return tasks;

        }

       
    }
}