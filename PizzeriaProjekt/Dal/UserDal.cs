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
            return context.Users.FirstOrDefault(x => x.Login == login);
        }

        public Object? Save(User user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }
    }
}
