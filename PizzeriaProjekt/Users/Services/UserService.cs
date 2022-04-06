using PizzeriaProjekt.DB;
using PizzeriaProjekt.Exceptions;
using PizzeriaProjekt.Model;
using PizzeriaProjekt.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                userDal.Save(user);
            }
            else
            {
                throw new UserAlreadyExistsException();
            }
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
