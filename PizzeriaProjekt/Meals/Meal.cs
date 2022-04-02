using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaProjekt.Meals
{
    internal abstract class Meal
    {
        [Column("MealId")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Category")]
        public Category Category { get; set; }

        [Column("ImageUrl")]
        public string? ImageUrl { get; set; }

        [Column("BasePrice", TypeName = "decimal(15,2)")]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        [NotMapped] 
        public decimal? ActualPrice { get; set; }
    }

    [Flags]
    enum Category
    {
        OTHER = 0,
        ITALIAN = 1,
        PIZZA = 2
    }
}
