using Persons.Service.Write.DomainModelLayer;
using System;

namespace Persons.Service.Write.InfrastructureLayer
{
    public interface IWriteRepository
    {
        Person Find(Guid id);

        void Insert(Person item);
    }
}
