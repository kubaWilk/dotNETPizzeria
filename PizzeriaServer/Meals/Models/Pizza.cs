namespace PizzeriaServer.Meals.Models
{
    public class Pizza : Meal
    {
        public virtual ICollection<PizzaTopping> PizzaToppings { get; } = new HashSet<PizzaTopping>();

        public Pizza()
        {
            Category = Category.ITALIAN | Category.PIZZA;
        }
    }
}
