using PizzeriaServer.Model;

namespace PizzeriaServer.Service
{
    internal interface IUserService
    {
        /// <summary>
        /// Returns true when User has been properly logged in, returns false when password is wrong. 
        /// </summary>
        /// <param name="username">User login</param>
        /// <param name="password">User Password</param>
        /// <returns></returns>
        bool LogIn(string username, string password);
        /// <summary>
        /// Method used to register a user
        /// </summary>
        /// <param name="user">Takes user data as a User object</param>
        void Register(User user);
        /// <summary>
        /// Updates data of current user (from CurrentUserContainer) that have been changed during the session
        /// </summary>
        void UpdateCurrentUser();

        /// <summary>
        /// Logs Out current user
        /// </summary>
        void LogOut();
    }
}