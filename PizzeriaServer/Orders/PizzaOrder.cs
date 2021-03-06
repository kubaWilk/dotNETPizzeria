using PizzeriaServer.Meals.Models;
using PizzeriaServer.Model;

namespace PizzeriaServer.Orders
{
    /// <summary>
    /// Pizza Order represents DTO response pizza order.
    /// </summary>
    public class PizzaOrder
    {
        public long OrderId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDone { get; set; }
        public string? UserNotes { get; set; }
        public List<Item> Items { get; set; }

        public decimal? ActualPrice { get; set; }

        public class Item
        {
            public long OrderLineId { get; set; }
            public long PositionInOrder { get; set; }
            public Pizza Pizza { get; set; }
            public PizzaCrust Crust { get; set; }
            public PizzaSize Size { get; set; }
            public List<Topping> ExtraToppings { get; set; }
            public decimal? ActualPrice { get; set; }
        }
    }
}
