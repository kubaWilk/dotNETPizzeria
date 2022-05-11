using PizzeriaServer.Meals.Models;
using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders.Services
{
    internal class OrderMapper
    {
        private OrderMapper()
        {
        }

        internal static Order mapToOrder(CreatePizzaOrder newOrderRequest)
        {
            List<PizzaOrderLine> pizzaOrderLines = newOrderRequest.Items.Select(item =>
            {
                PizzaOrderLine orderLine = new PizzaOrderLine
                {
                    PizzaId = item.PizzaId,
                    SizeId = item.PizzaSizeId,
                    CrustId = item.PizzaCrustId
                };

                if (item.ExtraToppingsIds != null && item.ExtraToppingsIds.Any())
                {
                    item.ExtraToppingsIds.ForEach(toppingId =>
                    {
                        orderLine.ExtraToppings.Add(new Topping { Id = toppingId });
                    });
                }

                return orderLine;
            }).ToList();

            Order order = new Order
            {
                UserId = newOrderRequest.UserId,
                UserNotes = newOrderRequest.UserNotes
            };
            pizzaOrderLines.ForEach(orderLine =>
            {
                order.OrderLines.Add(orderLine);
            });

            return order;
        }

        internal static PizzaOrder mapToSavedPizzaOrder(Order savedOrder)
        {
            long positionInOrder = 0;
            List<PizzaOrder.Item> items = savedOrder.OrderLines.Select(orderLine => new PizzaOrder.Item
            {
                OrderLineId = orderLine.Id,
                PositionInOrder = ++positionInOrder,
                Pizza = orderLine.Pizza,
                Crust = orderLine.Crust,
                Size = orderLine.Size,
                ExtraToppings = orderLine.ExtraToppings.ToList()
            }).ToList();

            return new PizzaOrder
            {
                OrderId = savedOrder.Id,
                CreatedAt = savedOrder.CreatedAt,
                IsDone = savedOrder.IsDone,
                User = savedOrder.User,
                UserNotes = savedOrder.UserNotes,
                Items = items
            };
        }
    }
}
