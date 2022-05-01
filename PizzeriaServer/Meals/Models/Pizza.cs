using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaServer.Meals.Models
{
    public class Pizza : Meal
    {
        public virtual ICollection<PizzaTopping> PizzaToppings { get; } = new HashSet<PizzaTopping>();

        [NotMapped]
        public PizzaSize Size { get; set; }

        [NotMapped]
        public PizzaCrust Crust { get; set; }

        public Pizza()
        {
            Category = Category.ITALIAN | Category.PIZZA;
            Size = PizzaSize.Small();
            Crust = PizzaCrust.Thin();
        }
    }
}
