using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProjekt.Model
{
    internal class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ExpritaionDate{ get; set; }
        public string CVV { get; set; }
    }
}
