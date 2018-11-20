using System;

namespace Persons.Abstractions.Write.Commands
{
    public class CreatePersonCommand
    {
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
