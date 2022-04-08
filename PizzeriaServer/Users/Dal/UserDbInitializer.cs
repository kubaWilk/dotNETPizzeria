using Microsoft.EntityFrameworkCore;
using PizzeriaServer.Model;

namespace PizzeriaServer.Users.Dal
{
    internal class UserDbInitializer
    {
        public static void SeedUser(ModelBuilder modelBuilder)
        {
            var defaultUser = new[]
            {
                new User{
                    Id = 1,
                    Login = "test",
                    Password = "TurboHard!23",
                    FirstName = "Jan",
                    LastName = "Nowak",
                    Birthday = new DateTime(1990, 1, 1),
                    PhoneNumber = "732121245",
                    Street = "Default",
                    City = "Default",
                    PostCode = "65-001"
                }
            };

            modelBuilder.Entity<User>().HasData(defaultUser);
        }
    }
}
