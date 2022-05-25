using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaServer;
using PizzeriaServer.Model;
using PizzeriaServer.Service;
using System;

namespace PizzeriaServerTests.TestUser
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void LogIn_ValidUserTriesToLogIn_ReturnsTrue()
        {
            UserService userService = new UserService(new UserDalMock());

            var result = userService.LogIn("test", "TurboHard!23");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LogIn_ValidUserTriesToLogIn_CurrentUserShouldBeAssigned()
        {
            UserService userService = new UserService(new UserDalMock());
            User user = new User
            {
                Id = 1,
                Login = "test",
                Password = "TurboHard!23",
                FirstName = "Jan",
                LastName = "Nowak",
                Birthday = new DateTime(1990, 1, 1),
                PhoneNumber = "732121245",
                Street = "Default",
                City = "Default",
                PostCode = "65-001"
            };

            userService.LogIn("test", "TurboHard!23");

            Assert.AreSame(user, CurrentUserContainer.s_currentUser);
        }
    }
}