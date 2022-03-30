using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProjekt.Model
{
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birtday { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<CreditCard> creditCards { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
