using PizzeriaServer.Dbo;
using Microsoft.EntityFrameworkCore;
using PizzeriaServer.Meals.Models;
using PizzeriaServer.Meals.Exceptions;

namespace PizzeriaServer.Meals.Dal
{
    internal class PizzaQueryDao : IPizzaQueryDao
    {
        private readonly MainDbContext _dbContext;

        public PizzaQueryDao()
        {
            _dbContext = new MainDbContext();
            _dbContext.Database.EnsureCreated();
        }

        public List<Pizza> GetPizzas()
        {
            List <Pizza> pizzas = _dbContext.Meals.OfType<Pizza>()
                .Include(pizza => pizza.PizzaToppings)
                .ThenInclude(pizzaTopping => pizzaTopping.Topping)
                .ToList();
            
            return pizzas;
        }

        public List<Topping> GetToppingsForPizza(long pizzaId)
        {
            Pizza? pizza = _dbContext.Meals.OfType<Pizza>()
                .Where(pizza => pizza.Id == pizzaId)
                .FirstOrDefault();

            if (pizza == null)
            {
                throw new PizzaNotFoundException($"Pizza with Id: {pizzaId} not found");
            }

            List<Topping> toppings = _dbContext.Toppings
                .Where(topping => topping.PizzaToppings
                    .Any(pizzaTopping => pizzaTopping.MealId == pizzaId))
                .ToList();

            return toppings;
        }

        public Topping GetToppingById(long toppingId)
        {
            Topping? topping = _dbContext.Toppings
                .Where(topping => topping.Id == toppingId)
                .FirstOrDefault();

            if (topping == null)
            {
                throw new ToppingNotFoundException($"Topping with Id: {toppingId} not found");
            }

            return topping;
        }

        public Pizza GetPizzaById(long pizzaId)
        {
            Pizza? pizza = _dbContext.Meals.OfType<Pizza>()
                .Where(pizza => pizza.Id == pizzaId)
                .Include(pizza => pizza.PizzaToppings)
                .ThenInclude(pizzaToppings => pizzaToppings.Topping)
                .FirstOrDefault();

            if (pizza == null)
            {
                throw new PizzaNotFoundException($"Pizza with Id: {pizzaId} not found");
            }

            return pizza;
        }
    }
}
