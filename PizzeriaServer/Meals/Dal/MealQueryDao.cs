using PizzeriaServer.Dbo;

namespace PizzeriaServer.Meals.Dal
{
    internal class MealQueryDao : IMealQueryDao
    {
        private readonly MainDbContext _dbContext;

        public MealQueryDao()
        {
            _dbContext = new MainDbContext();
            _dbContext.Database.EnsureCreated();
        }

        public List<Meal> GetMeals()
        {
            List<Meal> meals = _dbContext.Meals.ToList();
            return meals;
        }
    }
}
