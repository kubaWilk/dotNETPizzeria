using PizzeriaServer.Meals.Models;

namespace PizzeriaServer.Meals.Services
{
    internal class MealPriceService
    {
        private readonly Dictionary<Type, IMealPriceCalculator> _priceCalculators;

        public MealPriceService()
        {
            _priceCalculators = new Dictionary<Type, IMealPriceCalculator>();
        }

        /// <summary>
        /// Calculates actual price of the <see cref="Meal"/>.
        /// Mutates state of <see cref="Meal"/> object: 
        /// updates <see cref="Meal.ActualPrice"/> field.
        /// </summary>
        public void UpdateActualPrice<T>(ref T meal) where T : Meal
        {
            Type typeOfMeal = meal.GetType();
            if (!_priceCalculators.ContainsKey(typeOfMeal))
            {
                throw new ArgumentException($"Cannot determine price for meal Id: {meal.Id}. " +
                    $"Did you forget to register IMealPriceCalculator?");
            }
            IMealPriceCalculator mealPriceCalculator = _priceCalculators[typeOfMeal];
            decimal price = mealPriceCalculator.calculate(meal);
            meal.ActualPrice = price;
        }

        public void RegisterPriceCalculator(IMealPriceCalculator mealPriceCalculator, Type typeOfMeal)
        {
            _priceCalculators[typeOfMeal] = mealPriceCalculator;
        }
    }
}
