using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Dal
{
    /// <summary>
    /// Defines a contract for mutating state of orders.
    /// </summary>
    internal interface IOrderMutationDao
    {
        /// <summary>
        /// Persist new <see cref="Order"/> along with all its 
        /// <see cref="PizzaOrderLine"/>'s.
        /// </summary>
        /// <param name="order">Order to save.</param>
        /// <returns>Saved <see cref="Order"/></returns>
        public Order SaveOrder(Order order);
    }
}