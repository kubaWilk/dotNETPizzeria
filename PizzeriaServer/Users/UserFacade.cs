using PizzeriaServer.DB;
using PizzeriaServer.Dbo;
using PizzeriaServer.Model;
using PizzeriaServer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaServer.Users
{
    public class UserFacade
    {
        private readonly IUserService _userService;

        public UserFacade()
        {
            _userService = new UserService(new UserDal());
        }

        public bool LogIn(string username, string password)
        {
            return _userService.LogIn(username, password);
        }

        public void Register(User user)
        {
            _userService.Register(user);
        }

        public void UpdateCurrentUser()
        {
            _userService.UpdateCurrentUser();
        }
    }
}
