using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TaskListApp.Lib.Data;
using WebApplication2;
using WebApplication2.Controllers;

namespace WebApplication2.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private IDatabase testDB;
        private string validuser = "validuser1";
        private string validpassword = "validpassword";
        private DBUser validUser;


        [TestInitialize]
        public void SetUp()
        {
            testDB = MockRepository.GenerateStub<IDatabase>();
            validUser = new DBUser() { Password = validpassword, Username = validuser };

            var defaultTasks = createTasks();

            testDB.Expect(s => s.GetUser(validuser)).Return(validUser);
            testDB.Expect(s => s.GetUser("baduser1")).Return(null);

            testDB.Expect(s => s.GetUserTasks(validUser)).Return(defaultTasks);
        }


        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
           // Assert.AreEqual("", result.ViewBag.Title);
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
