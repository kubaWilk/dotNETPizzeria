namespace PizzeriaProjekt.Meals
{
    /// <summary>
    /// Strategy for the calculation of an actual price of the meal.
    /// </summary>
    internal interface IMealPriceCalculator
    {
        /// <summary>
        /// Calculates an actual price of the <see cref="Meal"/>.
        /// </summary>
        /// <param name="meal"></param>
        /// <returns>Actual price of the meal.</returns>
        public decimal calculate(Meal meal);
    }
}
