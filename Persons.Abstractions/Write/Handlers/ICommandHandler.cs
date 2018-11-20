using Persons.Abstractions.Write.Commands;
using System;

namespace Persons.Abstractions.Write.Handlers
{
    public interface ICommandHandler
    {
        Guid? Handle(CreatePersonCommand createPersonCommand);
    }
}
