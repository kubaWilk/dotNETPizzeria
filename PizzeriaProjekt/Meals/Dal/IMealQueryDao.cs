namespace PizzeriaProjekt.Meals
{
    /// <summary>
    /// Defines a contract for querying the meals.
    /// </summary>
    internal interface IMealQueryDao
    {
        /// <summary>
        /// Get all objects of type <see cref="Meal"/>.
        /// </summary>
        /// <returns>List of <see cref="Meal"/> or empty if no meal is present.</returns>
        public List<Meal> GetMeals();
    }
}
