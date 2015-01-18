using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TaskListApp.Lib.Data;

namespace WebApplication2.Tests
{
    [TestClass]
    public class UserTests
    {
        private IDatabase testDB;
        private string validuser = "validuser1";
        private string validpassword = "validpassword";
        private DBUser validUser;

        [TestInitialize]
        public void SetUp()
        {
           testDB = MockRepository.GenerateStub<IDatabase>();
           validUser = new DBUser() {Password = validpassword, Username = validuser};

            var defaultTasks = createTasks();

           testDB.Expect(s => s.GetUser(validuser)).Return(validUser);
           testDB.Expect(s => s.GetUser("baduser1")).Return(null);

            testDB.Expect(s => s.GetUserTasks(validUser)).Return(defaultTasks);
        }

        [TestMethod]
        public void UserIsValid_returns_true()
        {
            var username = "validuser1";
            var password = "validpassword";

            var user = new WebApplication2.Models.User(testDB);
            Assert.IsTrue(user.isValid(username, password));
        }

        [TestMethod]
        public void UserIsNotValid_returns_false()
        {
            var username = "baduser1";
            var password = "testpass";
           
            var user = new Models.User(testDB);
            Assert.IsFalse(user.isValid(username, password));
        }

        [TestMethod]
        public void UserTasks_returns_tasks()
        {
            var username = "validuser1";
            
            var user = testDB.GetUser(username);
            var tasks = testDB.GetUserTasks(user);

            Assert.IsTrue(tasks.Count==3);

        }


        private List<DBTask> createTasks()
        {
            return new List<DBTask>()
            {
                new DBTask()
                {
                    CreatedDate = DateTime.Now.AddDays(-10),
                    ModifiedDate = DateTime.Now.AddDays(-2),
                    Title = "A Great Task",
                    Description = "A Description of the task",
                    State = DBState.Active
                },
            new DBTask()
                {
                    CreatedDate = DateTime.Now.AddDays(-3),
                    ModifiedDate = DateTime.Now.AddDays(-1),
                    Title = "A Super Task",
                    Description = "A note of the task",
                    State = DBState.Archived
                },
                 new DBTask()
                {
                    CreatedDate = DateTime.Now.AddDays(-8),
                    ModifiedDate = DateTime.Now.AddDays(-4),
                    Title = "A Marvellous Task",
                    Description = "A summary of the task",
                    State = DBState.Completed
                }
            };
        } 

    }
}
