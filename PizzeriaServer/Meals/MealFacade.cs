using PizzeriaServer.Meals.Dal;
using PizzeriaServer.Meals.Models;
using PizzeriaServer.Meals.Services;

namespace PizzeriaServer.Meals
{
    /// <summary>
    /// Facade service that aggregates and exposes all methods for querying
    /// or mutating <see cref="Meal"/>s state.
    /// </summary>
    public class MealFacade
    {
        private readonly IMealService _mealService;
        private readonly IPizzaService _pizzaService;
        private readonly MealPriceService _mealPriceService;

        public MealFacade()
        {
            _mealService = new MealService(new MealQueryDao());
            _pizzaService = new PizzaService(new PizzaQueryDao());
            _mealPriceService = new MealPriceService();
            _mealPriceService.RegisterPriceCalculator(new PizzaPriceCalculator(), typeof(Pizza));
        }

        /// <summary>
        /// Get all <see cref="Meal"/>s.
        /// </summary>
        /// <returns>List of <see cref="Meal"/> or empty if no meal is present.</returns>
        public List<Meal> GetMeals()
        {
            List<Meal> meals = _mealService.GetMeals();
            return meals;
        }

        /// <summary>
        /// Get all <see cref="Pizza"/>s.
        /// </summary>
        /// <returns>List of <see cref="Pizza"/> or empty if no pizza is present.</returns>
        public List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = _pizzaService.GetPizzas();

            pizzas.ForEach(pizza => _mealPriceService.UpdateActualPrice(ref pizza));
            
            return pizzas;
        }

        /// <summary>
        /// Get pizza by id.
        /// </summary>
        /// <param name="pizzaId">Pizza's Id</param>
        /// <returns><see cref="Pizza"></see></returns>
        public Pizza GetPizzaById(long pizzaId)
        {
            Pizza pizza = _pizzaService.GetPizzaById(pizzaId);
            _mealPriceService.UpdateActualPrice(ref pizza);
            return pizza;
        }

        /// <summary>
        /// Get all associated toppings with pizza.
        /// </summary>
        /// <param name="pizzaId">Pizza's Id</param>
        /// <returns>List of <see cref="Topping"></see> or empty list of there's 
        /// no associated toppings with given pizza.</returns>
        public List<Topping> GetToppingsForPizza(long pizzaId)
        {
            List<Topping> toppings = _pizzaService.GetToppingsForPizza(pizzaId);
            return toppings;
        }

        /// <summary>
        /// Get <see cref="Topping"/> by id.
        /// </summary>
        /// <param name="toppingId">Topping's Id</param>
        /// <returns></returns>
        public Topping GetToppingById(long toppingId)
        {
            Topping topping = _pizzaService.GetToppingById(toppingId);
            return topping;
        }
    }
}
