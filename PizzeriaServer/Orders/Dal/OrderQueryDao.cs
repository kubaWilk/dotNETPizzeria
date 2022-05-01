using PizzeriaServer.Dbo;
using Microsoft.EntityFrameworkCore;
using PizzeriaServer.Orders.Models;
using PizzeriaServer.Orders.Exceptions;
using PizzeriaServer.Meals;
using PizzeriaServer.Meals.Models;

namespace PizzeriaServer.Orders.Dal
{
    public class OrderQueryDao
    {
        private readonly MainDbContext _dbContext;

        private readonly MealFacade _mealFacade;

        public OrderQueryDao()
        {
            _dbContext = new MainDbContext();
            _dbContext.Database.EnsureCreated();
            _mealFacade = new MealFacade();
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = _dbContext.Orders
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

        public void SaveOrder(Order order)
        {
            
            //foreach (PizzaOrderLine orderLine in order.OrderLines)
            //{
            //    Pizza pizza = _mealFacade.GetPizzaById(orderLine.PizzaId);

            //    //foreach (Topping extraTopping in orderLine.ExtraToppings)
            //    //{
            //    //    Topping topping = _mealFacade.GetToppingById(extraTopping.Id);
            //    //    _dbContext.Entry(topping).State = EntityState.Unchanged;
            //    //}

            //    orderLine.Pizza = pizza;
            //    _dbContext.Entry(pizza).State = EntityState.Unchanged;
            //}
            _dbContext.Orders.Attach(order);
            _dbContext.SaveChanges();
        }
    }
}
