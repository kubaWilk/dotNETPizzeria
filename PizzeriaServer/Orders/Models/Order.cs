using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaServer.Orders.Models
{
    public class Order
    {
        [Key]
        [Column("OrderId")]
        public long Id { get; set; }

        [Column("CreatedAt", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("IsDone", TypeName = "bit(1)")]
        public bool IsDone { get; set; }

        [Column("UserNotes")]
        public string? UserNotes { get; set; }

        public virtual ICollection<PizzaOrderLine> OrderLines { get; set; }
    }
}
