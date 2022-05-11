using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Services
{
    /// <summary>
    /// Represents business logic layer and establishes a set of available operations 
    /// for <see cref="Order"/> domain object and associated classes such as <see cref="PizzaOrderLine"/>, 
    /// and other classes which Order cannot exists without.
    /// </summary>
    internal interface IOrderService
    {
        /// <summary>
        /// Persist new <see cref="Order"/> along with all its 
        /// <see cref="PizzaOrderLine"/>'s.
        /// </summary>
        /// <param name="newOrderRequest"><see cref="CreatePizzaOrder"/> contains all order data.</param>
        /// <returns>Saved <see cref="Order"/></returns>
        public PizzaOrder CreateOrder(CreatePizzaOrder newOrderRequest);

        /// <summary>
        /// Get all objects of type <see cref="Order"/>.
        /// </summary>
        /// <returns>List of <see cref="PizzaOrder"/> or empty if no order is present.</returns
        public List<PizzaOrder> GetOrders();

        /// <summary>
        /// Get <see cref="Order"/> by id.
        /// </summary>
        /// <param name="orderId">Order's Id</param>
        /// <returns><see cref="PizzaOrder"/></returns>
        /// <exception cref="OrderNotFoundException">Thrown when order 
        /// with given id is not found.</exception>
        public PizzaOrder GetOrderById(long orderId);

        /// <summary>
        /// Get <see cref="PizzaOrder"/> by <see cref="User"/>'s id.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>List of <see cref="PizzaOrder"/> of the user or 
        /// empty list, if there doesn't exist any order associated with the user.</returns>
        public List<PizzaOrder> GetOrdersByUserId(long userId);
    }
}
