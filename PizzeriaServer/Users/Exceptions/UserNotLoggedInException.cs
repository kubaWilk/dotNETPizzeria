namespace PizzeriaServer.Users.Exceptions
{
    public class UserNotLoggedInException : Exception
    {
        public UserNotLoggedInException() : base() { }
        public UserNotLoggedInException(string message) : base(message) { }
        public UserNotLoggedInException(string message, Exception innerException) : base(String.Format(message, innerException)) { }
    }
}
