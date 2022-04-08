using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaServer.Users.Exceptions
{
    internal class UserNotLoggedInException : Exception
    {
        public UserNotLoggedInException() : base() { }
        public UserNotLoggedInException(string message) : base(message) { }
        public UserNotLoggedInException(string message, Exception innerException) : base(String.Format(message, innerException)) { }
    }
}
