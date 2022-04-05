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
            //User defaultUser = new User()
            //{
            //    Id = 1,
            //    Login = "test",
            //    Password = "test",
            //    FirstName = "Jan",
            //    LastName = "Nowak",
            //    Birthday = new DateTime(1990, 1, 1),
            //    PhoneNumber = "732121245",
            //    Street = "Default",
            //    City = "Default",
            //    PostCode = "Default"
            //};

            var defaultUser = new[]
            {
                new User{
                    Id = 1,
                    Login = "test",
                    Password = "test",
                    FirstName = "Jan",
                    LastName = "Nowak",
                    Birthday = new DateTime(1990, 1, 1),
                    PhoneNumber = "732121245",
                    Street = "Default",
                    City = "Default",
                    PostCode = "Default"
                }
            };

            //modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("Id");
            //modelBuilder.Entity<User>().Property(x => x.Login).HasColumnName("Login");
            //modelBuilder.Entity<User>().Property(x => x.Password).HasColumnName("Password");
            //modelBuilder.Entity<User>().Property(x => x.FirstName).HasColumnName("FirstName");
            //modelBuilder.Entity<User>().Property(x => x.LastName).HasColumnName("LastName");
            //modelBuilder.Entity<User>().Property(x => x.Birthday).HasColumnName("Birthday");
            //modelBuilder.Entity<User>().Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
            //modelBuilder.Entity<User>().Property(x => x.Street).HasColumnName("Street");
            //modelBuilder.Entity<User>().Property(x => x.City).HasColumnName("City");
            //modelBuilder.Entity<User>().Property(x => x.PostCode).HasColumnName("PostCode");

            modelBuilder.Entity<User>().HasData(defaultUser);
        }
    }
}
