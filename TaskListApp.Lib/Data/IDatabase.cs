using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TaskListApp.Lib.Data
{
    public interface IDatabase
    {
        List<DBUser> GetUsers();
        DBUser GetUser(string username);
        bool AddUser(DBUser user);
        bool AddUser(string username, string password);

        List<DBTask> GetTasks();
        List<DBTask> GetUserTasks(DBUser user);

        bool SaveTask(DBTask task,DBUser user);
        DBTask GetTask(int id);
        
        bool HasUsers();
    }

    public class DBUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<DBTask> Tasks { get; set; } 
    }
    public class DBTask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DBState State { get; set; }

        public int Id { get; set; }
    }

    public enum DBState
    {
        Active=0,
        Completed=1,
        Archived=9
    }
}
