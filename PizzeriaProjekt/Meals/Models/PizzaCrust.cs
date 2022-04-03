using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaProjekt.Meals.Model
{
    internal class PizzaCrust
    {
        [Key]
        [Column("CrustId")]
        public long Id { get; set; }

        [Column("Name")]
        public CrustType Name { get; set; }

        [Column("BasePrice", TypeName = "decimal(15,2)")]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        internal enum CrustType
        {
            THIN, THICK
        }
    }
}
