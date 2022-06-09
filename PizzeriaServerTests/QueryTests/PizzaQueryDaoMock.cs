using PizzeriaServer.Meals.Dal;
using PizzeriaServer.Meals.Exceptions;
using PizzeriaServer.Meals.Models;
using System.Collections.Generic;
namespace PizzeriaServerTests
{
    internal class PizzaQueryDaoMock : IPizzaQueryDao
    {
        private List<Pizza> pizzaList;
        private List<Topping> toppingList;

        public PizzaQueryDaoMock()
        {
            pizzaList = new List<Pizza>();
            toppingList = new List<Topping>();

            Topping topping = new Topping()
            {
                Id = 1,
                Name = "Topping",
                BasePrice = 2.0m
            };

            PizzaTopping pizzaTopping = new PizzaTopping()
            {
                MealId = 1,
                ToppingId = 1,
                Topping = topping
            };

            Pizza pizza = new Pizza()
            {
                Id = 1,
                Name = "Pizza",
                Category = Category.ITALIAN,
                BasePrice = 14.0m,
                ActualPrice = 16.0m
            };
            pizzaTopping.Pizza = pizza;
            pizza.PizzaToppings.Add(pizzaTopping);
            pizzaList.Add(pizza);
            toppingList.Add(topping);
        }

        public Pizza GetPizzaById(long pizzaId)
        {
            var result = pizzaList.Find(x => x.Id == pizzaId);

            if (result == null)
            {
                throw new PizzaNotFoundException($"Pizza with Id: {pizzaId} not found");
            }

            return result;
        }

        public List<Pizza> GetPizzas()
        {
            return pizzaList;
        }

        public Topping GetToppingById(long toppingId)
        {
            var result = toppingList.Find(x => x.Id == toppingId);

            if (result == null)
            {
                throw new ToppingNotFoundException($"Topping with Id: {toppingId} not found");
            }

            return result;
        }

        public List<Topping> GetToppingsForPizza(long pizzaId)
        {
            var pizza = GetPizzaById(pizzaId);

            List<Topping> result = new List<Topping>();

            foreach (PizzaTopping top in pizza.PizzaToppings)
            {
                result.Add(top.Topping);
            }

            return result;
        }
    }
}


