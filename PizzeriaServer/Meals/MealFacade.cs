using PizzeriaServer.Meals.Dal;
using PizzeriaServer.Meals.Services;

namespace PizzeriaServer.Meals
{
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

        public List<Meal> GetMeals()
        {
            List<Meal> meals = _mealService.GetMeals();
            return meals;
        }

        public List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = _pizzaService.GetPizzas();

            pizzas.ForEach(pizza => _mealPriceService.UpdateActualPrice(ref pizza));
            
            return pizzas;
        }

        public List<Topping> GetToppingsForPizza(long pizzaId)
        {
            List<Topping> toppings = _pizzaService.GetToppingsForPizza(pizzaId);
            return toppings;
        }

        public Topping GetToppingById(long toppingId)
        {
            Topping topping = _pizzaService.GetToppingById(toppingId);
            return topping;
        }
    }
}
