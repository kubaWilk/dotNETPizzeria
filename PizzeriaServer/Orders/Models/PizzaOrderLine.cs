using PizzeriaServer.Meals.Models;

namespace PizzeriaServer.Orders.Models
{
    public class PizzaOrderLine : OrderLine
    {
        public Pizza Pizza { get; set; }
        public virtual ICollection<Topping> ExtraToppings { get; set; }
    }
}
