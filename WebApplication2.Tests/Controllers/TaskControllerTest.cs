using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskListApp.Lib.Data;
using WebApplication2;
using WebApplication2.Controllers;

namespace WebApplication2.Tests.Controllers
{
    [TestClass]
    public class TaskControllerTest
    {
        [TestMethod]
        public void Get()
        {
            var fakeDB = new FakeLocalDatabase();//mock out

            // Arrange
           TaskController controller = new TaskController(fakeDB);
           controller.forceUser = "validuser1";
            
            // Act
            IEnumerable<Models.Task> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Models.Task taskAtElement0 = result.ElementAt(0);

            Assert.AreEqual(taskAtElement0.Title, "A Great Task");
            
        }

        [TestMethod]
        public void GetById()
        {
            var fakeDB = new FakeLocalDatabase();//mock out

            // Arrange
            TaskController controller = new TaskController(fakeDB);
            controller.forceUser = "validuser1";
            // Act
            Models.Task result = controller.Get(2);

            // Assert
            Assert.AreEqual(result.Title, "A Marvellous Task");
        }

        [TestMethod]
        public void Post()
        {
            var fakeDB = new FakeLocalDatabase();//mock out

            // Arrange
            TaskController controller = new TaskController(fakeDB);
            controller.forceUser = "validuser1";
            // Act
            var newTask = new Models.Task()
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Description = "A Testing task",
                State = 0,
                Title = "A TEST"
            };
            controller.Post(newTask);

            // Assert
            var alltasks=controller.Get();
            var tskMax = alltasks.Max(s => s.Id);
            var task = alltasks.First(t => t.Id == tskMax);
            Assert.AreEqual(task.Title, newTask.Title);
            Assert.AreEqual(task.Description, newTask.Description);
            Assert.AreEqual(task.ModifiedDate, newTask.ModifiedDate);
            Assert.AreEqual(task.CreatedDate, newTask.CreatedDate);
            
        }

        [TestMethod]
        public void Put()
        {
            var fakeDB = new FakeLocalDatabase();//mock out
            // Arrange
            TaskController controller = new TaskController(fakeDB);
            controller.forceUser = "validuser1";

            var task = controller.Get(2);

            task.Title = "An updated Title";
            // Act
            controller.Put(2, task);

            var updTask = controller.Get(2);
            // Assert

            Assert.AreEqual(updTask.Title,task.Title);

        }
    }
}
