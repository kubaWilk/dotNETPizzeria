using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaProjekt.Meals.Model
{
    internal class PizzaSize
    {
        [Key]
        [Column("PizzaSizeId")]
        public long Id { get; set; }

        [Column("Name")]
        public SizeType Name { get; set; }

        [Column("Diameter")]
        public int DiameterCentimeters { get; set; }

        [Column("BasePrice", TypeName = "decimal(15,2)")]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        internal enum SizeType
        {
            SMALL = 20,
            MEDIUM = 30,
            LARGE = 50
        }
    }
}
