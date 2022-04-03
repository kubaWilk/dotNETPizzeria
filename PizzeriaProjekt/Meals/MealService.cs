using PizzeriaProjekt.Dbo;
using Microsoft.EntityFrameworkCore;

namespace PizzeriaProjekt.Meals
{
    internal class MealService : IMealQueryService
    {
        public List<Meal> GetMeals()
        {
            using (var dbContext = new MainDbContext())
            {
                dbContext.Database.EnsureCreated();

                List<Meal> meals = dbContext.Meals.ToList();
                return meals;
            }
        }
        public List<Pizza> GetPizzas()
        {
            using (var dbContext = new MainDbContext())
            {
                dbContext.Database.EnsureCreated();

                List<Pizza> pizzas = dbContext.Meals.OfType<Pizza>().ToList();
                return pizzas;
            }
        }

        public List<Topping> GetToppingsForPizza(long pizzaId)
        {
            using (var dbContext = new MainDbContext())
            {
                dbContext.Database.EnsureCreated();

                Pizza? pizza = dbContext.Meals.OfType<Pizza>()
                    .Where(pizza => pizza.Id == pizzaId)
                    .Include(pizza => pizza.PizzaToppings)
                    .FirstOrDefault();

                if (pizza == null)
                {
                    throw new PizzaNotFoundException($"Pizza with Id: {pizzaId} not found");
                }

                List<Topping> toppings = pizza.PizzaToppings.ToList()
                    .ConvertAll(new Converter<PizzaTopping, Topping>(ExtractTopping));

                return toppings;
            }
        }

        public Topping GetToppingById(long toppingId)
        {
            using (var dbContext = new MainDbContext())
            {
                dbContext.Database.EnsureCreated();

                Topping? topping = dbContext.Toppings
                    .Where(topping => topping.Id == toppingId)
                    .FirstOrDefault();

                if (topping == null)
                {
                    throw new ToppingNotFoundException($"Topping with Id: {toppingId} not found");
                }

                return topping;
            }
        }

        private Topping ExtractTopping(PizzaTopping pizzaTopping)
        {
            using (var dbContext = new MainDbContext())
            {
                dbContext.Database.EnsureCreated();

                Topping topping = GetToppingById(pizzaTopping.ToppingId);
                return topping;
            }
        }
    }
}
