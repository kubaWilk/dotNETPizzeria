using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaProjekt.Meals
{
    internal class Topping
    {
        [Column("ToppingId")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("BasePrice", TypeName = "decimal(15,2)")]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        public ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
