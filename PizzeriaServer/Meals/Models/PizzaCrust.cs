using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaServer.Meals.Model
{
    public class PizzaCrust
    {
        [Key]
        [Column("CrustId")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("BasePrice", TypeName = "decimal(15,2)")]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        public static PizzaCrust Thin()
        {
            return new PizzaCrust
            {
                Id = 1,
                Name = "Thin",
                BasePrice = 0.0m
            };
        }

        public static PizzaCrust Thick()
        {
            return new PizzaCrust 
            { 
                Id = 2, 
                Name = "Thick", 
                BasePrice = 2.0m 
            };
        }
    }
}
