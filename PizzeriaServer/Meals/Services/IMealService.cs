namespace PizzeriaServer.Meals.Services
{
    /// <summary>
    /// Represents business logic layer and establishes a set of available operations 
    /// for <see cref="Meal"/> domain object.
    /// </summary>
    internal interface IMealService
    {
        /// <summary>
        /// Get all objects of type <see cref="Meal"/>.
        /// </summary>
        /// <returns>List of <see cref="Meal"/> or empty if no meal is present.</returns>
        public List<Meal> GetMeals();
    }
}
