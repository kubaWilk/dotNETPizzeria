using PizzeriaServer.Dbo;
using PizzeriaServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaServer.DB
{
    internal class UserDal
    {
        private MainDbContext context = new MainDbContext();
        public User? GetUserByLogin(string login)
        {
            var user = context.Users.FirstOrDefault(x => x.Login == login);
            return user;
        }
    }
}
