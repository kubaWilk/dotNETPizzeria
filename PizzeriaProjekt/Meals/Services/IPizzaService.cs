﻿namespace PizzeriaProjekt.Meals.Services
{
    /// <summary>
    /// Represents business logic layer and establishes a set of available operations 
    /// for <see cref="Pizza"/> domain object and associated classes such as <see cref="Topping"/>, 
    /// and other class which Pizza cannot exists without.
    /// </summary>
    internal interface IPizzaService
    {
        /// <summary>
        /// Get all objects of type <see cref="Pizza"/>.
        /// </summary>
        /// <returns>List of <see cref="Pizza"/> or empty if no pizza is present.</returns>
        public List<Pizza> GetPizzas();

        /// <summary>
        /// Get <see cref="Topping"/> by id.
        /// </summary>
        /// <param name="toppingId">Topping's Id</param>
        /// <returns></returns>
        public Topping GetToppingById(long toppingId);

        /// <summary>
        /// Get all associated toppings with pizza.
        /// </summary>
        /// <param name="pizzaId">Pizza's Id</param>
        /// <returns>List of <see cref="Topping"></see> or empty list of there's 
        /// no associated toppings with given pizza.</returns>
        public List<Topping> GetToppingsForPizza(long pizzaId);
    }
}
