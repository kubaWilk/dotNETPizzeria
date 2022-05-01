using PizzeriaServer.Meals.Models;

namespace PizzeriaServer.Meals.Dal
{
    /// <summary>
    /// Defines a contract for querying pizzas.
    /// </summary>
    internal interface IPizzaQueryDao
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
        /// <returns><see cref="Topping"/></returns>
        /// <exception cref="ToppingNotFoundException">Thrown when topping 
        /// with given id is not found.</exception>
        public Topping GetToppingById(long toppingId);

        /// <summary>
        /// Get pizza by id.
        /// </summary>
        /// <param name="pizzaId">Pizza's Id</param>
        /// <returns><see cref="Pizza"></see></returns>
        public Pizza GetPizzaById(long pizzaId);

        /// <summary>
        /// Get all associated toppings with pizza.
        /// </summary>
        /// <param name="pizzaId">Pizza's Id</param>
        /// <returns>List of <see cref="Topping"></see> or empty list of there's 
        /// no associated toppings with given pizza.</returns>
        /// <exception cref="PizzaNotFoundException">Thrown when pizza 
        /// with given id is not found.</exception>
        public List<Topping> GetToppingsForPizza(long pizzaId);
    }
}
