using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaServer.Orders.Models
{
    public class OrderLine
    {
        [Key]
        [Column("OrderLineId")]
        public int Id { get; set; }

        [Column("CreatedAt", TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        [Column("IsDone", TypeName = "bit(1)")]
        public bool IsDone { get; set; }
    }
}
