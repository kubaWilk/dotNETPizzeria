using PizzeriaServer.Dbo;
using PizzeriaServer.Exceptions;
using PizzeriaServer.Model;

namespace PizzeriaServer.DB
{
    internal class UserDal : IUserDal
    {
        private readonly MainDbContext _userContext;

        public UserDal()
        {
            _userContext = new MainDbContext();
            _userContext.Database.EnsureCreated();
        }

        public User? GetUserByLogin(string login)
        {
            try
            {
                return _userContext.Users.FirstOrDefault(x => x.Login == login);
            }
            catch (NullReferenceException)
            {
                throw new UserNotFoundException();
            }
        }

        public void Save(User user)
        {
            //TODO: no argument == null checking
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
        }

        public void Update(User user)
        {
            //TODO: no argument == null checking

            var DbUser = _userContext.Users
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

            _userContext.SaveChanges();
        }

        public void Delete(User user)
        {
            //TODO: no argument == null checking

            var DbUser = _userContext.Users.First(x => x.Login == user.Login);

            if (DbUser == null) throw new UserNotFoundException();

            _userContext.Users.Remove(DbUser);
        }
    }
}
