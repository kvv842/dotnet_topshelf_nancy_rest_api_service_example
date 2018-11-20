using System;

namespace Persons.Exceptions
{
    public class UnprocessableEntity : Exception
    {
        public UnprocessableEntity(string message):base(message)
        {

        }
    }
}
