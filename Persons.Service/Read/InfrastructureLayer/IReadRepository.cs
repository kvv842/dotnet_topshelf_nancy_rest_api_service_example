using Persons.Service.Read.DomainModelLayer;
using System;

namespace Persons.Service.Read.InfrastructureLayer
{
    public interface IReadRepository
    {
        Person GetById(Guid id);
    }
}
