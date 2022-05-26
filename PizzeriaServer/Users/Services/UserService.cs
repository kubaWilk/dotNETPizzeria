using PizzeriaServer.DB;
using PizzeriaServer.Exceptions;
using PizzeriaServer.Model;
using PizzeriaServer.Users.Exceptions;
using System.Text.RegularExpressions;


namespace PizzeriaServer.Service
{
    internal class UserService : IUserService
    {
        private readonly IUserDal userDal;

        public UserService(IUserDal userDal)
        {
            this.userDal = userDal;
        }

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

            user = userDal.GetUserByLogin(username);
            if (user == null) throw new UserNotFoundException();

            if (user.Password == password)
            {
                CurrentUserContainer.s_currentUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Register(User user)
        {
            if(user == null) throw new InvalidDataException("User can't be null");

            if (userDal.GetUserByLogin(user.Login) == null)
            {
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
            if (user == null) throw new InvalidDataException("User can't be null!");

            Regex LoginRegex = new Regex(@"^[a-zA-Z0-9]{3,}$");
            Regex PasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
            Regex NameRegex = new Regex(@"^[A-Za-z ]+$");
            Regex PhoneNumberRegex = new Regex(@"^+\d{9,12}$");
            Regex StreetRegex = new Regex(@"^[A-Źa-ź0-9 /]+$");
            Regex CityRegex = new Regex(@"^[A-Źa-ź ]+$");
            Regex PostCodeRegex = new Regex(@"[0-9]{2}[-][0-9]{3}");

            if (!LoginRegex.IsMatch(user.Login)) throw new InvalidDataException("Wrong login format");
            if (!PasswordRegex.IsMatch(user.Password)) throw new InvalidDataException("Wrong password format");
            if (!NameRegex.IsMatch(user.FirstName)) throw new InvalidDataException("Wrong first name format");
            if (!NameRegex.IsMatch(user.LastName)) throw new InvalidDataException("Wrong last name format");
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
                checkUserData(CurrentUserContainer.s_currentUser);
                userDal.Update(currentUser);
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}