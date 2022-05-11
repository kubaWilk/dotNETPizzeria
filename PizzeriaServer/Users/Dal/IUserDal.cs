using PizzeriaServer.Model;

namespace PizzeriaServer.DB
{
    internal interface IUserDal
    {
        /// <summary>
        /// Method used to find user in database by login
        /// </summary>
        /// <param name="login">Login of user to find</param>
        /// <returns>Returns User with given login</returns>
        User? GetUserByLogin(string login);
        /// <summary>
        /// Method used to delete user from database
        /// </summary>
        /// <param name="user"></param>
        void Delete(User user);
        /// <summary>
        /// Method used to save new user in database
        /// </summary>
        /// <param name="user">Takes User object to save in dataabse</param>
        void Save(User user);
        /// <summary>
        /// Method used to update user data
        /// </summary>
        /// <param name="user">Takes updated user object and saves changes in database</param>
        void Update(User user);
    }
}