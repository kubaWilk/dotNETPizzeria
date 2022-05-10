using PizzeriaServer.Meals.Dal;
using PizzeriaServer.Meals.Models;

namespace PizzeriaServer.Meals.Services
{
    public  class PizzaService : IPizzaService
    {
        private readonly IPizzaQueryDao _pizzaQueryDao;

        public PizzaService(IPizzaQueryDao pizzaQueryDao)
        {
            _pizzaQueryDao = pizzaQueryDao;
        }

        public List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = _pizzaQueryDao.GetPizzas();
            return pizzas;
        }

        public List<Topping> GetToppingsForPizza(long pizzaId)
        {
            List<Topping> toppings = _pizzaQueryDao.GetToppingsForPizza(pizzaId);
            return toppings;
        }

        public Topping GetToppingById(long toppingId)
        {
            Topping topping = _pizzaQueryDao.GetToppingById(toppingId);
            return topping;
        }
    }
}
