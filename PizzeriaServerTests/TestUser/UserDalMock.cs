using PizzeriaServer;
using PizzeriaServer.DB;
using PizzeriaServer.Exceptions;
using PizzeriaServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaServerTests.TestUser
{
    internal class UserDalMock : IUserDal
    {
        private List<User> users;

        public UserDalMock()
        {
            users = new List<User>();

            users.Add(new User
            {
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
            });

            users.Add(new User
            {
                Id = 2,
                Login = "test2",
                Password = "TurboHard!23",
                FirstName = "Jan2",
                LastName = "Nowak2",
                Birthday = new DateTime(1990, 1, 1),
                PhoneNumber = "732121245",
                Street = "Default",
                City = "Default",
                PostCode = "65-001"
            });
        }

        public void Delete(User user)
        {
            User temp = users.Find(x => x.Id == user.Id);

            if (temp == null) throw new UserNotFoundException();

            users.Remove(user);
        }

        public User? GetUserByLogin(string login)
        {
            User result = users.Find(x => x.Login == login);
            if (result == null) throw new UserNotFoundException();

            return result;
        }

        public void Save(User user)
        {
            User temp = users.Find(x => x.Id == user.Id);

            if (temp != null) throw new UserAlreadyExistsException();

            users.Add(user);
        }

        public void Update(User user)
        {
            User temp = users.Find(x => x.Id == user.Id);

            if (temp == null) throw new UserNotFoundException();

            users.Remove(temp);
            temp.Id = user.Id;
            temp.Password = user.Password;
            temp.Birthday = user.Birthday;
            temp.Street = user.Street;
            temp.City = user.City;
            temp.PostCode = user.PostCode;
            temp.PhoneNumber = user.PhoneNumber;
            users.Add(temp);
        }
    }
}
