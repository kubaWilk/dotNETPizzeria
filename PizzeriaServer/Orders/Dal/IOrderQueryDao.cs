using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Dal
{
    /// <summary>
    /// Defines a contract for querying orders.
    /// </summary>
    internal interface IOrderQueryDao
    {
        /// <summary>
        /// Get all objects of type <see cref="Order"/>.
        /// </summary>
        /// <returns>List of <see cref="Order"/> or empty if no order is present.</returns>
        public List<Order> GetOrders();

        /// <summary>
        /// Get <see cref="Order"/> by id.
        /// </summary>
        /// <param name="orderId">Order's Id</param>
        /// <returns><see cref="Order"/></returns>
        /// <exception cref="OrderNotFoundException">Thrown when order 
        /// with given id is not found.</exception>
        public Order GetOrderById(long orderId);

        /// <summary>
        /// Get <see cref="PizzaOrder"/> by <see cref="User"/>'s id.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>List of <see cref="PizzaOrder"/> of the user or 
        /// empty list, if there doesn't exist any order associated with the user.</returns>
        List<Order> GetOrdersByUserId(long userId);
    }
}
