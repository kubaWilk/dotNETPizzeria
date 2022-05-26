using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaServer;
using PizzeriaServer.Exceptions;
using PizzeriaServer.Model;
using PizzeriaServer.Service;
using System;
using System.IO;

namespace PizzeriaServerTests.UserTesting
{
    [TestClass]
    public class UserServiceTests
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

            userService.LogIn(existingUser.Login, existingUser.Password);

            Assert.AreEqual(existingUser, CurrentUserContainer.s_currentUser);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void LogIn_NullLoginAndPassword_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());

            userService.LogIn(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void LogIn_WrongCredentials_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());

            userService.LogIn("wrong", "credentials");
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void LogIn_EmptyCredentials_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());

            userService.LogIn("", "");
        }

        [TestMethod]
        public void UpdateCurrentUser_WithValidUserData_ShouldPass()
        {
            UserService userService = new UserService(new UserDalMock());
            userService.LogIn(existingUser.Login, existingUser.Password);
            var currUser = CurrentUserContainer.s_currentUser;
            currUser.FirstName = "Changed";

            userService.UpdateCurrentUser();

            Assert.AreEqual("Changed", CurrentUserContainer.s_currentUser.FirstName);
        }

        private readonly User existingUser = new User
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

        private readonly User user = new User
        {
            Id = 5,
            Login = "test5",
            Password = "TurboHard!23",
            FirstName = "Jan",
            LastName = "Nowak",
            Birthday = new DateTime(1990, 1, 1),
            PhoneNumber = "732121245",
            Street = "Default",
            City = "Default",
            PostCode = "65-001"
        };
    }
}