using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaServer.Meals
{
    public class Topping
    {
        [Key]
        [Column("ToppingId")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("BasePrice", TypeName = "decimal(15,2)")]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        public virtual ICollection<PizzaTopping> PizzaToppings { get; set; }
    }
}
