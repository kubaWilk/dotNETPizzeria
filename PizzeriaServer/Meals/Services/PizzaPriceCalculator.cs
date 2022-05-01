using PizzeriaServer.Meals.Models;

namespace PizzeriaServer.Meals.Services
{
    internal class PizzaPriceCalculator : IMealPriceCalculator
    {
        public decimal calculate(Meal meal)
        {
            if (meal is Pizza)
            {
                Pizza pizza = (Pizza)meal;
                ICollection<PizzaTopping> pizzaToppings = pizza.PizzaToppings;

                decimal total = pizza.BasePrice;
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
