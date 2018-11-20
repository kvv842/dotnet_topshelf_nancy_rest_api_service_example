using System;
using Persons.Abstractions.Write.Commands;
using Persons.Abstractions.Write.Handlers;
using Persons.Exceptions;
using Persons.Service.Write.ApplicationLayer;
using Topshelf.Logging;

namespace Persons.Write.Handlers
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IPersonService _personService;

        private static readonly LogWriter _log = HostLogger.Get<CommandHandler>();

        public CommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public Guid? Handle(CreatePersonCommand createPersonCommand)
        {
            _log.Debug($"CreatePersonCommand Name: {createPersonCommand.Name}; BirthDay: {createPersonCommand.BirthDay}");

            var person = _personService.Create(createPersonCommand.Name, createPersonCommand.BirthDay);

            if (person == null)
                throw new UnprocessableEntity("Person not valid.");

            return person?.Id;
        }
    }
}
