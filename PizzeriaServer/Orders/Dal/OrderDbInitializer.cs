using Microsoft.EntityFrameworkCore;
using PizzeriaServer.Meals.Models;
using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Dal
{
    internal class OrderDbInitializer
    {
        public static void SeedOrder(ModelBuilder modelBuilder)
        {
            var orders = new[]
            {
                new Order{ Id = 1 },
                new Order{ Id = 2 }
            };

            var pizzaData = new[]
            {
                new Pizza{Id = 1, Name = "Margherita", BasePrice = 20.00m},
                new Pizza{Id = 2, Name = "Capricciosa", BasePrice = 23.00m},
                new Pizza{Id = 3, Name = "Japanelo", BasePrice = 23.00m},
                new Pizza{Id = 4, Name = "Hawaii", BasePrice = 24.00m}
            };

            var orderLines = new PizzaOrderLine[4];
            for (int i = 0; i < 4; i++)
            {
                orderLines[i] = new PizzaOrderLine
                {
                    Id = i + 1,
                    OrderId = i % 2 + 1,
                    PizzaId = i + 1
                };
            }

            //modelBuilder.Entity<Order>(order =>
            //{
            //    order.HasData(orders);
            //    order.OwnsMany(o => o.OrderLines).HasData(new PizzaOrderLine[]
            //    {
            //        { Id = 1, OrderId = 1, PizzaId = 1, Pizza },
            //        { Id = 2, OrderId = 1, PizzaId = 2 },
            //        { Id = 3, OrderId = 2, PizzaId = 3 },
            //        { Id = 4, OrderId = 3, PizzaId = 4 },
            //    });
            //});

            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<PizzaOrderLine>().HasData(orderLines);
        }
    }
}
