using Microsoft.EntityFrameworkCore;
using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Dal
{
    internal class OrderDbInitializer
    {
        public static void SeedOrder(ModelBuilder modelBuilder)
        {
            var orders = new[]
            {
                new Order{ Id = 1, UserId = 1 },
                new Order{ Id = 2, UserId = 1 }
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

            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<PizzaOrderLine>().HasData(orderLines);
        }
    }
}
