﻿using PizzeriaServer.Dbo;
using PizzeriaServer.Exceptions;
using PizzeriaServer.Model;

namespace PizzeriaServer.DB
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
                catch (NullReferenceException)
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
                var DbUser = context.Users
                    .First(x => x.Id == user.Id);

                if (DbUser == null) throw new UserNotFoundException();

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
        }

        public void Delete(User user)
        {
            using (var context = new MainDbContext())
            {
                var DbUser = context.Users.First(x => x.Login == user.Login);

                if (DbUser == null) throw new UserNotFoundException();

                context.Users.Remove(DbUser);
            }
        }
    }
}