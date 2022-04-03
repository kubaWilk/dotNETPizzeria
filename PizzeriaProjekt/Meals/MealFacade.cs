using PizzeriaProjekt.Meals.Dal;
using PizzeriaProjekt.Meals.Services;

namespace PizzeriaProjekt.Meals
{
    internal class MealFacade
    {
        private readonly IMealService _mealService;
        private readonly IPizzaService _pizzaService;

        public MealFacade()
        {
            _mealService = new MealService(new MealQueryDao());
            _pizzaService = new PizzaService(new PizzaQueryDao());
        }

        public List<Meal> GetMeals()
        {
            List<Meal> meals = _mealService.GetMeals();
            return meals;
        }

        public List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = _pizzaService.GetPizzas();
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
