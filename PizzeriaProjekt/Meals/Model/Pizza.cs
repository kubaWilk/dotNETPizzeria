﻿using PizzeriaProjekt.Meals.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaProjekt.Meals
{
    internal class Pizza : Meal
    {
        public ICollection<PizzaTopping> PizzaToppings { get; set; }

        [NotMapped]
        public PizzaSize Size { get; set; }

        [NotMapped]
        public PizzaCrust Crust { get; set; }

        public Pizza()
        {
            Category = Category.ITALIAN | Category.PIZZA;
        }
    }
}
