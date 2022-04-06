using Microsoft.EntityFrameworkCore;
using PizzeriaServer.Meals.Model;

namespace PizzeriaServer.Meals.Dal
{
    internal class MealDbInitializer
    {
        public static void SeedPizza(ModelBuilder modelBuilder)
        {
            var pizzas = new[]
            {
                new Pizza{Id = 1, Name = "Margherita", BasePrice = 20.00m},
                new Pizza{Id = 2, Name = "Capricciosa", BasePrice = 23.00m},
                new Pizza{Id = 3, Name = "Japanelo", BasePrice = 23.00m},
                new Pizza{Id = 4, Name = "Hawaii", BasePrice = 24.00m},
            };

            var toppings = new[]
            {
                new Topping{Id = 1, Name = "Mozzarella", BasePrice = 2.00m},
                new Topping{Id = 2, Name = "Ham", BasePrice = 2.00m},
                new Topping{Id = 3, Name = "Japanelo", BasePrice = 2.00m},
                new Topping{Id = 4, Name = "Pepperoni", BasePrice = 2.00m},
                new Topping{Id = 5, Name = "Pineapple", BasePrice = 2.00m},
            };

            var pizzaToppings = new[]
            {
                new PizzaTopping{MealId = pizzas[0].Id, ToppingId = toppings[0].Id},

                new PizzaTopping{MealId = pizzas[1].Id, ToppingId = toppings[0].Id},
                new PizzaTopping{MealId = pizzas[1].Id, ToppingId = toppings[1].Id},

                new PizzaTopping{MealId = pizzas[2].Id, ToppingId = toppings[0].Id},
                new PizzaTopping{MealId = pizzas[2].Id, ToppingId = toppings[3].Id},
                new PizzaTopping{MealId = pizzas[2].Id, ToppingId = toppings[4].Id},

                new PizzaTopping{MealId = pizzas[3].Id, ToppingId = toppings[0].Id},
                new PizzaTopping{MealId = pizzas[3].Id, ToppingId = toppings[2].Id},
                new PizzaTopping{MealId = pizzas[3].Id, ToppingId = toppings[4].Id}
            };

            var pizzaCrusts = new[]
            {
                PizzaCrust.Thin(), PizzaCrust.Thick()
            };

            var pizzaSizes = new[]
            {
                PizzaSize.Small(), PizzaSize.Medium(), PizzaSize.Large()
            };

            modelBuilder.Entity<Pizza>().HasData(pizzas);
            modelBuilder.Entity<Topping>().HasData(toppings);
            modelBuilder.Entity<PizzaTopping>().HasData(pizzaToppings);
            modelBuilder.Entity<PizzaCrust>().HasData(pizzaCrusts);
            modelBuilder.Entity<PizzaSize>().HasData(pizzaSizes);
        }
    }
}
