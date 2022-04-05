using PizzeriaProjekt.Meals.Services;

namespace PizzeriaProjekt.Meals
{
    internal class MealService : IMealService
    {
        private readonly IMealQueryDao _mealQueryDao;

        public MealService(IMealQueryDao mealQueryDao)
        {
            _mealQueryDao = mealQueryDao;
        }

        public List<Meal> GetMeals()
        {
            List<Meal> meals = _mealQueryDao.GetMeals();
            return meals;
        }
    }
}
