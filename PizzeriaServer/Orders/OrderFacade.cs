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
        private readonly OrderPriceCalculator _orderPriceCalculator;

        public OrderFacade()
        {
            _orderService = new OrderService(new OrderQueryDao(), new OrderMutationDao());
            _orderPriceCalculator = new OrderPriceCalculator();
        }

        /// <summary>
        /// Create new pizza order.
        /// </summary>
        /// <param name="newOrderRequest"><see cref="CreatePizzaOrder"/> contains 
        /// all data necessary for creation of new pizza order.</param>
        /// <returns><see cref="SavedPizzaOrder"/></returns>
        public SavedPizzaOrder CreateOrder(CreatePizzaOrder newOrderRequest)
        {
            SavedPizzaOrder order = _orderService.CreateOrder(newOrderRequest);

            _orderPriceCalculator.UpdateActualPrice(ref order);

            return order;
        }

        /// <summary>
        /// Get list of all persisted pizza orders.
        /// </summary>
        /// <returns>List of <see cref="SavedPizzaOrder"/> or empty if no order exists.</returns>
        public List<SavedPizzaOrder> GetOrders()
        {
            List<SavedPizzaOrder> orders = _orderService.GetOrders();

            orders.ForEach(order => _orderPriceCalculator.UpdateActualPrice(ref order));

            return orders;
        }

        /// <summary>
        /// Get <see cref="SavedPizzaOrder"/> by order id.
        /// </summary>
        /// <param name="orderId">Order's id.</param>
        /// <returns><see cref="SavedPizzaOrder"/></returns>
        /// <exception cref="OrderNotFoundException">Thrown when order 
        /// with given id is not found.</exception>
        public SavedPizzaOrder GetOrderById(long orderId)
        {
            SavedPizzaOrder order = _orderService.GetOrderById(orderId);

            _orderPriceCalculator.UpdateActualPrice(ref order);

            return order;
        }
    }
}
