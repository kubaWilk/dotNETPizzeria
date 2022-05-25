using PizzeriaServer.Meals.Dal;
using PizzeriaServer.Meals.Exceptions;
using PizzeriaServer.Meals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
