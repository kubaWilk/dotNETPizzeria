﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaProjekt.Meals
{
    internal class PizzaTopping
    {
        [Column("MealId")]
        public long MealId { get; set; }

        public Pizza Pizza { get; set; }

        [Column("ToppingId")]
        public long ToppingId { get; set; }

        public Topping Topping { get; set; }
    }
}
