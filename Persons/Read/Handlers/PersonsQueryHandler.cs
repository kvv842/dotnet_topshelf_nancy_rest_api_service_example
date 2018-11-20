using Persons.Abstractions.Read.Dto;
using Persons.Abstractions.Read.Handlers;
using Persons.Abstractions.Read.Query;
using Persons.Exceptions;
using Persons.Service.Read.DomainModelLayer;
using Persons.Service.Read.InfrastructureLayer;

namespace Persons.Read.Handlers
{
    public class PersonsQueryHandler : IQueryHandler
    {
        private readonly IReadRepository _readRepository;

        public PersonsQueryHandler(IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public PersonDto Get(GetPersonByIdQuery getPersonByIdQuery)
        {
            var person = _readRepository.GetById(getPersonByIdQuery.Id);

            if (person == null)
                throw new NotFound("Person not found.");

            return Map(person);
        }

        public PersonDto Map(Person person)
        {
            if (person == null)
                return null;

            return new PersonDto { BirthDay = person.BirthDay, Name = person.Name };
        }

    }
}
