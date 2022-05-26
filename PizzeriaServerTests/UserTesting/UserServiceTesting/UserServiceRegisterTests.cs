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
    public class UserServiceRegisterTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Register_WithNullUser_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());

            userService.Register(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UserAlreadyExistsException))]
        public void Register_WithExistingUser_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            User userTest = new User
            {
                Id = 1,
                Login = "test",
                Password = "TurboHard!23",
                FirstName = "Jan",
                LastName = "Nowak",
                Birthday = new DateTime(1990, 1, 1),
                PhoneNumber = "732121245",
                Street = "Default 21/37",
                City = "Default",
                PostCode = "65-001"
            };

            userService.Register(userTest);
        }

        [TestMethod]
        public void Register_WithNewUser_ShouldPass()
        {
            UserService userService = new UserService(new UserDalMock());

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong login format")]
        public void Register_LoginWithSpecialChars_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.Login = "test#$@%@#$%";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong login format")]
        public void Register_TooShortLogin_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.Login = "aa";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong password format")]
        public void Register_PasswordWithNoSpecialChars_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.Password = "TurboHard123";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong password format")]
        public void Register_PasswordWithNolowerCase_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.Password = "TURBOHARD!23";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong password format")]
        public void Register_PasswordWithNoUpperCase_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.Password = "turbohard!23";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong password format")]
        public void Register_PasswordWithNoNumbers_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.Password = "TurboHard!@#";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong password format")]
        public void Register_TooShortPassword_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.Password = "Pas!23$";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong first name format")]
        public void Register_FirstNameWithNumbers_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.FirstName = "Imie123";

            userService.Register(user);
        }

        [TestMethod]
        public void Register_FirstNameWithSpaces_ShouldPass()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.FirstName = "Imie junior";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong last name format")]
        public void Register_LastNameWithNumbers_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.LastName = "LastName123";

            userService.Register(user);
        }

        [TestMethod]
        public void Register_LastNameWithSpaces_ShouldPass()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.FirstName = "Long Last Name";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong phone number format")]
        public void Register_PhoneNumberWithCharacters_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.PhoneNumber = "654654654asdf";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong phone number format")]
        public void Register_PhoneNumberWithLessThan9Digits_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.PhoneNumber = "65465465";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong street format")]
        public void Register_StreetWithSpecialCharacters_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.Street = "Street !/@";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong city format")]
        public void Register_CityWithSpecialChars_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.City = "City!@#";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong city format")]
        public void Register_CityWithNumbers_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.City = "City123";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong post code format")]
        public void Register_PostCodeWithSpecialCharachters_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.PostCode = "65-!@#";

            userService.Register(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException), "Wrong post code format")]
        public void Register_PostCodeWithLetters_ShouldThrowAnException()
        {
            UserService userService = new UserService(new UserDalMock());
            var test = user;

            test.PostCode = "65-asd";

            userService.Register(user);
        }

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