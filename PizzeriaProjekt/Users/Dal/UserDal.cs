using PizzeriaProjekt.Dbo;
using PizzeriaProjekt.Exceptions;
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
        public User? GetUserByLogin(string login)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    return context.Users.FirstOrDefault(x => x.Login == login);
                }
                catch (NullReferenceException e)
                {
                    throw new UserNotFoundException();
                }
            }
        }

        public void Save(User user)
        {
            using (var context = new MainDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void Update(User user)
        {
            using (var context = new MainDbContext())
            {
                try
                {
                    var DbUser = context.Users
                        .First(x => x.Id == user.Id);

                    DbUser.Password = user.Password;
                    DbUser.FirstName = user.FirstName;
                    DbUser.LastName = user.LastName;
                    DbUser.Birthday = user.Birthday;
                    DbUser.PhoneNumber = user.PhoneNumber;
                    DbUser.Street = user.Street;
                    DbUser.City = user.City;
                    DbUser.PostCode = user.PostCode;

                    context.SaveChanges();
                }
                catch (NullReferenceException e)
                {
                    throw new UserNotFoundException();
                }
            }
        }
    }
}
