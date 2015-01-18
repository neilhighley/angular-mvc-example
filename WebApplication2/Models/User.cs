using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using TaskListApp.Lib.Data;
using WebApplication2.Helpers;

namespace WebApplication2.Models
{
    /// <summary>
    /// User model and db validation
    /// </summary>
    public class User
    {
        private IDatabase db;

        /// <summary>
        /// Pass a valid IDatabase for user validation purposes
        /// </summary>
        /// <param name="_db"></param>
        public User(IDatabase _db)
        {
            db = _db;
            VerifyDefaultUsers();
        }

        /// <summary>
        /// If no database is passed, go into fake mode
        /// </summary>
        public User()
        {
            db = new LocalDatabase();
            VerifyDefaultUsers();
        }

        private void VerifyDefaultUsers()
        {
            var u = db.GetUsers();
            if (!db.HasUsers())
            {
                //add test users
                using (var xdb = new Database1Entities1())
                {
                    var u1 = xdb.Users.Create();
                    u1.Username = "validuser1";
                    u1.Password = LoginHelper.EncodeAsSHA1("password");
                    xdb.Users.Add(u1);

                    var u2 = xdb.Users.Create();
                    u2.Username = "validuser2";
                    u2.Password = LoginHelper.EncodeAsSHA1("password");
                    xdb.Users.Add(u2);

                    xdb.SaveChanges();

                }
            }
        }

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        public List<Task> Tasks { get; set; } 


        /// <summary>
        /// Checks passed database for user existing
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool isValid(string username, string password)
        {
            var user=db.GetUser(username);

            if (user == null)
            {
                if (ConfigurationManager.AppSettings["initialise_users"] == "true")
                {
                    db.AddUser(username,password);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return user.Password == LoginHelper.EncodeAsSHA1(password);
            }
        }
    }

}