using PizzeriaServer.Meals.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaServer.Orders.Models
{
    public class PizzaOrderLine
    {

        [Key]
        [Column("OrderLineId")]
        public long Id { get; set; }

        public Order Order { get; set; }

        [ForeignKey("Order")]
        public long OrderId { get; set; }

        public Pizza Pizza { get; set; }

        [ForeignKey("Pizza")]
        public long PizzaId { get; set; }
        
        public PizzaCrust Crust { get; set; }
        
        [ForeignKey("Crust")]
        public long CrustId { get; set; }
        
        public PizzaSize Size { get; set; }
        
        [ForeignKey("Size")]
        public long SizeId { get; set; }

        public virtual ICollection<Topping> ExtraToppings { get; } = new HashSet<Topping>();
    }
}
