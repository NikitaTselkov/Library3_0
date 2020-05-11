using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model.UserFolder;

namespace Model.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var nameUser = Guid.NewGuid().ToString();
            var pasword = Guid.NewGuid().ToString();
            var lastName = Guid.NewGuid().ToString();
            var age = 123;
            var gender = Gender.Male;
            var access = Access.Admin;
            var controller = new UserController(nameUser, pasword);

            // Act
            controller.SetNewUserData(lastName, age, gender, access);
            var controller2 = new UserController(nameUser, pasword);

            // Assert
            Assert.AreEqual(controller2.CurrentUser.Firstname, nameUser);
            Assert.AreEqual(controller2.CurrentUser.Lastname, lastName);
            Assert.AreEqual(controller2.CurrentUser.Age, age);
            Assert.AreEqual(controller2.CurrentUser.Gender, gender);
            Assert.AreEqual(controller2.CurrentUser.Access, access);
            Assert.AreNotEqual(controller2.CurrentUser.Password, pasword);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var nameUser = Guid.NewGuid().ToString();
            var pasword = Guid.NewGuid().ToString();

            // Act
            var controller = new UserController(nameUser, pasword);
             
            // Assert
            Assert.AreEqual(nameUser, controller.CurrentUser.Firstname);
            Assert.AreNotEqual(pasword, controller.CurrentUser.Password);
        }
    }
}