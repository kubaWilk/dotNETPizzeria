using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaProjekt.Meals
{
    internal class Pizza : Meal
    {
        [Column("Size")]
        public PizzaSize Size { get; set; }

        [Column("DoughThickness")]
        public PizzaDoughThickness DoughThickness { get; set; }

        public ICollection<PizzaTopping> PizzaToppings { get; set; }

        public Pizza()
        {
            Category = Category.ITALIAN | Category.PIZZA;
            Size = PizzaSize.MEDIUM;
            DoughThickness = PizzaDoughThickness.THIN;
        }
            
        internal enum PizzaSize
        {
            SMALL, MEDIUM, LARGE
        }

        internal enum PizzaDoughThickness
        {
            THIN, THICK
        }
    }
}
