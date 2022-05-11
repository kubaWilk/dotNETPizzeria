using PizzeriaServer.Dbo;
using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Dal
{
    internal class OrderMutationDao : IOrderMutationDao
    {
        private readonly MainDbContext _dbContext;

        public OrderMutationDao()
        {
            _dbContext = new MainDbContext();
            _dbContext.Database.EnsureCreated();
        }

        public Order SaveOrder(Order order)
        {
            _dbContext.Orders.Attach(order);
            _dbContext.SaveChanges();
            return order;
        }
    }
}
