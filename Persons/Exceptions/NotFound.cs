using System;

namespace Persons.Exceptions
{
    public class NotFound: Exception
    {
        public NotFound(string message) : base(message)
        {

        }
    }
}
