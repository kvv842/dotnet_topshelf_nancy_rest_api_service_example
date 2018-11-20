using Persons.Service.Write.DomainModelLayer;
using Persons.Service.Write.InfrastructureLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Service.Write.ApplicationLayer
{
    public class PersonService: IPersonService
    {
        private readonly IWriteRepository repository;

        public PersonService(IWriteRepository writeRepository)
        {
            repository = writeRepository;
        }

        public Person Create(string name, DateTime birthDay)
        {
            var person = Person.Create(name, birthDay);

            if (person != null)
            {
                repository.Insert(person);
            }

            return person;
        }
    }
}
