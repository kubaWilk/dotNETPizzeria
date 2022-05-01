using PizzeriaServer.Dbo;
using Microsoft.EntityFrameworkCore;
using PizzeriaServer.Orders.Models;
using PizzeriaServer.Orders.Exceptions;

namespace PizzeriaServer.Orders.Dal
{
    internal class OrderQueryDao : IOrderQueryDao
    {
        private readonly MainDbContext _dbContext;

        public OrderQueryDao()
        {
            _dbContext = new MainDbContext();
            _dbContext.Database.EnsureCreated();
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = _dbContext.Orders
                .Include(order => order.User)
                .Include(order => order.OrderLines)
                .ThenInclude(orderLine => orderLine.Pizza)
                .ThenInclude(pizza => pizza.PizzaToppings)
                .Include(order => order.OrderLines)
                .ThenInclude(orderLine => orderLine.Crust)
                .Include(order => order.OrderLines)
                .ThenInclude(orderLine => orderLine.Size)
                .Include(order => order.OrderLines)
                .ThenInclude(orderLine => orderLine.ExtraToppings)
                .ToList();

            return orders;
        }

        public Order GetOrderById(long orderId)
        {
            {
                Order? order = _dbContext.Orders
                    .Where(order => order.Id == orderId)
                    .FirstOrDefault();

                if (order == null)
                {
                    throw new OrderNotFoundException($"Order with Id: {orderId} not found");
                }

                return order;
            }
        }
    }
}
