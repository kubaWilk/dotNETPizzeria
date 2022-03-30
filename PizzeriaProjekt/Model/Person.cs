using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProjekt.Model
{
    /// <summary>
    /// This is a class containing user's details
    /// Addresses and creditCards are HashSets because User can use multiple ones, yet we don't want duplicates
    /// </summary>
    internal class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birtday { get; set; }
        public HashSet<Address> Addresses { get; set; }
        public HashSet<CreditCard> creditCards { get; set; }
    }
}
