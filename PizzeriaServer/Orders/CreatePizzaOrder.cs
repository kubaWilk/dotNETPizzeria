namespace PizzeriaServer.Orders
{
    /// <summary>
    /// Simplified Pizza Order class. Basically it represent DTO object for creating 
    /// new pizza order.
    /// </summary>
    public class CreatePizzaOrder
    {
        public int UserId { get; set; }
        public string? UserNotes { get; set; }
        public List<Item> Items { get; set; }

        public class Item
        {
            public long PizzaId { get; set; }
            public long PizzaSizeId { get; set; }
            public long PizzaCrustId { get; set; }
            public List<long> ExtraToppingsIds { get; set; }
        }
    }
}