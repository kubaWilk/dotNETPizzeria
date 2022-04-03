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
        public string Name { get; set; }

        [Column("Diameter")]
        public int DiameterCentimeters { get; set; }

        [Column("BasePrice", TypeName = "decimal(15,2)")]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        public static PizzaSize Small()
        {
            return new PizzaSize
            {
                Id = 1,
                Name = "Small",
                DiameterCentimeters = 20,
                BasePrice = 0.0m
            };
        }

        public static PizzaSize Medium()
        {
            return new PizzaSize
            {
                Id = 2,
                Name = "Medium",
                DiameterCentimeters = 30,
                BasePrice = 8.0m
            };
        }

        public static PizzaSize Large()
        {
            return new PizzaSize
            {
                Id = 3,
                Name = "Large",
                DiameterCentimeters = 45,
                BasePrice = 18.0m
            };
        }
    }
}
