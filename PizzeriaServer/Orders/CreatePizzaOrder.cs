using PizzeriaServer.Meals.Models;

namespace PizzeriaServer.Orders
{
    /// <summary>
    /// Simplified Pizza Order class. Basically it represent DTO object for creating 
    /// new pizza order.
    /// </summary>
    public class CreatePizzaOrder
    {
        /// <value>
        /// User's ID.
        /// </value>
        public int UserId { get; set; }
        /// <value>
        /// (Optional) User's additional notes.
        /// </value>
        public string? UserNotes { get; set; }
        /// <value>
        /// Order lines in order.
        /// </value>
        public List<Item> Items { get; set; }
        /// <summary>
        /// Represents order line.
        /// </summary>
        public class Item
        {
            /// <value>
            /// <see cref="Pizza"/>'s ID.
            /// </value>
            public long PizzaId { get; set; }
            /// <value>
            /// <see cref="PizzaSize"/>'s ID.
            /// </value>
            public long PizzaSizeId { get; set; }
            /// <value>
            /// <see cref="PizzaCrust"/>'s ID.
            /// </value>
            public long PizzaCrustId { get; set; }
            /// <value>
            /// (Optional) Additional <see cref="Topping"/>'s.
            /// </value>
            public List<long> ExtraToppingsIds { get; set; }
        }
    }
}