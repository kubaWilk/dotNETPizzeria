using PizzeriaServer.Orders.Dal;
using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Services
{
    internal class OrderService : IOrderService
    {

        private readonly IOrderQueryDao _orderQueryDao;
        private readonly IOrderMutationDao _orderMutationDao;

        public OrderService(IOrderQueryDao orderQueryDao,
                            IOrderMutationDao orderMutationDao)
        {
            _orderQueryDao = orderQueryDao;
            _orderMutationDao = orderMutationDao;
        }

        public SavedPizzaOrder CreateOrder(CreatePizzaOrder newOrderRequest)
        {
            Order orderToSave = OrderMapper.mapToOrder(newOrderRequest);

            Order order = _orderMutationDao.SaveOrder(orderToSave);

            Order savedOrder = _orderQueryDao.GetOrderById(order.Id);

            return OrderMapper.mapToSavedPizzaOrder(savedOrder);
        }

        public List<SavedPizzaOrder> GetOrders()
        {
            List<Order> orders = _orderQueryDao.GetOrders();

            return orders.Select(order => OrderMapper.mapToSavedPizzaOrder(order))
                .ToList();
        }

        public SavedPizzaOrder GetOrderById(long orderId)
        {
            Order order = _orderQueryDao.GetOrderById(orderId);

            return OrderMapper.mapToSavedPizzaOrder(order);
        }
    }
}
