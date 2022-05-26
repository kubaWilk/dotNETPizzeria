using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaServer.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;

            if(obj is User user)
            {
                return this.Id == user.Id &&
                    this.Login == user.Login &&
                    this.Password == user.Password &&
                    this.FirstName == user.FirstName &&
                    this.LastName == this.LastName &&
                    this.Birthday.Equals(user.Birthday) &&
                    this.PhoneNumber == user.PhoneNumber &&
                    this.Street == user.Street &&
                    this.City == user.City &&
                    this.PostCode == user.PostCode;
            }

            return false;
        }
    }
}
