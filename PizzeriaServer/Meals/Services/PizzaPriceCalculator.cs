using PizzeriaServer.Meals.Model;

namespace PizzeriaServer.Meals
{
    internal class PizzaPriceCalculator : IMealPriceCalculator
    {
        public decimal calculate(Meal meal)
        {
            if (meal is Pizza)
            {
                Pizza pizza = (Pizza)meal;
                PizzaCrust crust = pizza.Crust;
                PizzaSize size = pizza.Size;
                ICollection<PizzaTopping> pizzaToppings = pizza.PizzaToppings;

                decimal total = pizza.BasePrice;
                total += crust.BasePrice;
                total += size.BasePrice;
                foreach (var topping in pizzaToppings)
                {
                    total += topping.Topping.BasePrice;
                }

                return total;
            }
            throw new InvalidCastException($"Cannot calculate price for: {meal.Id}.");
        }
    }
}
