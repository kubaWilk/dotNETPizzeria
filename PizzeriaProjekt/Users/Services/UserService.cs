using PizzeriaProjekt.DB;
using PizzeriaProjekt.Exceptions;
using PizzeriaProjekt.Model;
using PizzeriaProjekt.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace PizzeriaProjekt.Service
{
    internal class UserService
    {
        private UserDal userDal = new UserDal();
        private object currentUserContainer;

        /// <summary>
        /// Returns true when User has been properly logged in, returns false when password is wrong. 
        /// Throws UserNotFoundException when login is wrong
        /// </summary>
        /// <param name="username">User login</param>
        /// <param name="password">User Password</param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException">Thrown when login's wrong.</exception>
        public bool LogIn(string username, string password)
        {
            User user;

            try
            {
                user = userDal.GetUserByLogin(username);
                if (user.Password == password)
                {
                    CurrentUserContainer.s_currentUser = user;
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(NullReferenceException e)
            {
                throw new UserNotFoundException();
            }
        }
        public void Register(User user)
        {
            if (userDal.GetUserByLogin(user.Login) == null) {
                checkUserData(user);
                userDal.Save(user);
            }
            else
            {
                throw new UserAlreadyExistsException();
            }
        }

        private void checkUserData(User user)
        {
            Regex LoginRegex = new Regex(@"(\w{1,}\d*)");
            Regex PasswordRegex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$");
            Regex FirstNameRegex = new Regex(@"((\w+)(\s*))*");
            Regex LastNameRegex = new Regex(@"((\w+)(\s*))*");
            Regex PhoneNumberRegex = new Regex(@"([+(\d]{1})(([\d+() -.]){5,16})([+(\d]{1})");
            Regex StreetRegex = new Regex(@"([^!@#$%^&*()_+-=]+)([a-ż ]+\s?)(\d{0,3})(\s?\S{2,})");
            Regex CityRegex = new Regex(@"([^!@#$%^&*()_+-=]+)([a-ż ]+\s?)");
            Regex PostCodeRegex = new Regex(@"[0-9]{2}[-][0-9]{3}");


            if (!LoginRegex.IsMatch(user.Login)) throw new InvalidDataException("Wrong login format");
            if (!PasswordRegex.IsMatch(user.Password)) throw new InvalidDataException("Wrong password format");
            if (!FirstNameRegex.IsMatch(user.FirstName)) throw new InvalidDataException("rong first name format");
            if (!LastNameRegex.IsMatch(user.LastName)) throw new InvalidDataException("Wrong last name format");
            if (!PhoneNumberRegex.IsMatch(user.PhoneNumber)) throw new InvalidDataException("Wrong phone number format");
            if (!StreetRegex.IsMatch(user.Street)) throw new InvalidDataException("Wrong street format");
            if (!CityRegex.IsMatch(user.City)) throw new InvalidDataException("Wrong city format");
            if (!PostCodeRegex.IsMatch(user.PostCode)) throw new InvalidDataException("Wrong post code format");
        }
        
        /// <summary>
        /// A method for updating logged in user. It should be used to save changes made to currentLoggedInUser during the session to the DB.
        /// </summary>
        /// <exception cref="UserNotLoggedInException">Thrown when currentLoggedInUser is null</exception>
        public void UpdateCurrentUser()
        {
            var currentUser = CurrentUserContainer.s_currentUser;

            if (userDal.GetUserByLogin(currentUser.Login) != null)
            {
                userDal.Update(currentUser);
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}
