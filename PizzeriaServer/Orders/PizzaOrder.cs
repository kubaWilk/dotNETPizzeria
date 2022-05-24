using PizzeriaServer.Meals.Models;
using PizzeriaServer.Model;
using PizzeriaServer.Orders.Models;

namespace PizzeriaServer.Orders
{
    /// <summary>
    /// Pizza Order represents DTO response pizza order.
    /// </summary>
    public class PizzaOrder
    {
        /// <value>
        /// <see cref="Order"/> ID.
        /// </value>
        public long OrderId { get; set; }
        /// <value>
        /// <see cref="User"/> associated with the order.
        /// </value>
        public User User { get; set; }
        /// <value>
        /// Date time when order was created.
        /// </value>
        public DateTime CreatedAt { get; set; }
        /// <value>
        /// Whenever the order was already prepared.
        /// </value>
        public bool IsDone { get; set; }
        /// <value>
        /// (Optional) Additional user notes.
        /// </value>
        public string? UserNotes { get; set; }
        /// <value>
        /// Order lines. <seealso cref="PizzaOrder.Item"/>
        /// </value>
        public List<Item> Items { get; set; }
        /// <value>
        /// Actual price of the order. May differ from sum of all <see cref="Items"/> depending
        /// on adopted calculation price strategy.
        /// </value>
        public decimal? ActualPrice { get; set; }

        /// <summary>
        /// Represent order line.
        /// </summary>
        public class Item
        {
            /// <value>
            /// <see cref="PizzaOrderLine"/>'s ID.
            /// </value>
            public long OrderLineId { get; set; }
            /// <value>
            /// Position in order.
            /// </value>
            public long PositionInOrder { get; set; }
            /// <value>
            /// <see cref="Pizza"/> associated with the order line.
            /// </value>
            public Pizza Pizza { get; set; }
            /// <value>
            /// Pizza's crust.
            /// </value>
            public PizzaCrust Crust { get; set; }
            /// <value>
            ///  Pizza's size.
            /// </value>
            public PizzaSize Size { get; set; }
            /// <value>
            /// (Optional) Additional <see cref="Topping"/>'s if order line contains such.
            /// </value>
            public List<Topping> ExtraToppings { get; set; }
            /// <value>
            /// Actual price of single order line.
            /// </value>
            public decimal? ActualPrice { get; set; }
        }
    }
}
