using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaProjekt.Exceptions
{
    internal class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base() { }
        public UserAlreadyExistsException(string message) : base(message) { }
        public UserAlreadyExistsException(string message, Exception innerException) : base(String.Format(message, innerException)) { }
    }
}
