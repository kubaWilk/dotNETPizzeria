using PizzeriaServer.Dbo;
using Microsoft.EntityFrameworkCore;
using PizzeriaServer.Orders.Models;
using PizzeriaServer.Orders.Exceptions;
using PizzeriaServer.Meals.Models;
using Microsoft.EntityFrameworkCore.Query;

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
            List<Order> orders = EagerlyLoadOrder()
                .ToList();

            return orders;
        }

        public Order GetOrderById(long orderId)
        {
            {
                Order? order = EagerlyLoadOrder()
                    .Where(order => order.Id == orderId)
                    .FirstOrDefault();

                if (order == null)
                {
                    throw new OrderNotFoundException($"Order with Id: {orderId} not found");
                }

                return order;
            }
        }

        public List<Order> GetOrdersByUserId(long userId)
        {
            List<Order> orders = EagerlyLoadOrder()
                .Where(order => order.UserId == userId)
                .ToList();

            return orders;
        }

        private IIncludableQueryable<Order, ICollection<Topping>> EagerlyLoadOrder()
        {
            return _dbContext.Orders
               .Include(order => order.User)
               .Include(order => order.OrderLines)
               .ThenInclude(orderLine => orderLine.Pizza)
               .ThenInclude(pizza => pizza.PizzaToppings)
               .ThenInclude(pizzaToping => pizzaToping.Topping)
               .Include(order => order.OrderLines)
               .ThenInclude(orderLine => orderLine.Crust)
               .Include(order => order.OrderLines)
               .ThenInclude(orderLine => orderLine.Size)
               .Include(order => order.OrderLines)
               .ThenInclude(orderLine => orderLine.ExtraToppings);
        }
    }
}
