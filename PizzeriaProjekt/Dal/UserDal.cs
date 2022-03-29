using PizzeriaProjekt.Dbo;
using PizzeriaProjekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProjekt.DB
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
