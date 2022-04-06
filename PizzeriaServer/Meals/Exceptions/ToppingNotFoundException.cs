namespace PizzeriaServer.Meals
{
    [Serializable]
    internal class ToppingNotFoundException : Exception
    {
        public ToppingNotFoundException(string? message) : base(message)
        {
        }

        public ToppingNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}