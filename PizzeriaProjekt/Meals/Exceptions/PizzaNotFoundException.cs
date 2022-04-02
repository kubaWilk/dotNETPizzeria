namespace PizzeriaProjekt.Meals
{
    [Serializable]
    internal class PizzaNotFoundException : Exception
    {
        public PizzaNotFoundException(string? message) : base(message)
        {
        }

        public PizzaNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}