using Microsoft.EntityFrameworkCore;
using PizzeriaProjekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProjekt.Users.Dal
{
    internal class UserDbInitializer
    {
        public static void SeedUser(ModelBuilder modelBuilder)
        {
            User defaultUser = new User()
            {
                Id = 1,
                Login = "test",
                Password = "test",
                FirstName = "Jan",
                LastName = "Nowak",
                Birtday = new DateTime(1990, 1, 1),
                PhoneNumber = "732121245",
                Street = "Default",
                City = "Default",
                PostCode = "Default"
            };

            modelBuilder.Entity<User>().HasData(defaultUser);
        }
    }
}
