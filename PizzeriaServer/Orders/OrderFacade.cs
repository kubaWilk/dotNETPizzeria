using PizzeriaServer.Orders.Dal;
using PizzeriaServer.Orders.Models;
using PizzeriaServer.Orders.Services;

namespace PizzeriaServer.Orders
{
    /// <summary>
    /// Facade service that aggregates and exposes all methods for querying
    /// or mutating <see cref="Order"/>s state.
    /// </summary>
    public class OrderFacade
    {

        private readonly IOrderService _orderService;
        private readonly OrderPriceService _pizzaOrderPriceService;

        /// <summary>
        /// No args constructor.
        /// </summary>
        public OrderFacade()
        {
            _orderService = new OrderService(new OrderQueryDao(), new OrderMutationDao());
            _pizzaOrderPriceService = new OrderPriceService();
        }

        /// <summary>
        /// Create new pizza order.
        /// </summary>
        /// <param name="newOrderRequest"><see cref="CreatePizzaOrder"/> contains 
        /// all data necessary for creation of new pizza order.</param>
        /// <returns><see cref="PizzaOrder"/></returns>
        public PizzaOrder CreateOrder(CreatePizzaOrder newOrderRequest)
        {
            PizzaOrder order = _orderService.CreateOrder(newOrderRequest);

            _pizzaOrderPriceService.UpdateActualPrice(ref order);

            return order;
        }

        /// <summary>
        /// Get list of all persisted pizza orders.
        /// </summary>
        /// <returns>List of <see cref="PizzaOrder"/> or empty if no order exists.</returns>
        public List<PizzaOrder> GetOrders()
        {
            List<PizzaOrder> orders = _orderService.GetOrders();

            orders.ForEach(order => _pizzaOrderPriceService.UpdateActualPrice(ref order));

            return orders;
        }

        /// <summary>
        /// Get <see cref="PizzaOrder"/> by order id.
        /// </summary>
        /// <param name="orderId">Order's id.</param>
        /// <returns><see cref="PizzaOrder"/></returns>
        /// <exception cref="OrderNotFoundException">Thrown when order 
        /// with given id is not found.</exception>
        public PizzaOrder GetOrderById(long orderId)
        {
            PizzaOrder order = _orderService.GetOrderById(orderId);

            _pizzaOrderPriceService.UpdateActualPrice(ref order);

            return order;
        }

        /// <summary>
        /// Get all <see cref="PizzaOrder"/>s of the user.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>List of <see cref="PizzaOrder"/> of the user or 
        /// empty list, if given user hasn't ordered anything.</returns>
        public List<PizzaOrder> GetUserOrderHistory(long userId)
        {
            List<PizzaOrder> userOrderHistory = _orderService.GetOrdersByUserId(userId);

            userOrderHistory.ForEach(order => _pizzaOrderPriceService.UpdateActualPrice(ref order));

            return userOrderHistory;
        }
    }
}
