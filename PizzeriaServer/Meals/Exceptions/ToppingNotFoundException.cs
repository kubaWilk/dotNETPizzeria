namespace PizzeriaServer.Meals
{
    [Serializable]
    public class ToppingNotFoundException : Exception
    {
        public ToppingNotFoundException(string? message) : base(message)
        {
        }

        public ToppingNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}