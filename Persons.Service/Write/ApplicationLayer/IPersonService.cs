using Persons.Service.Write.DomainModelLayer;
using System;

namespace Persons.Service.Write.ApplicationLayer
{
    public interface IPersonService
    {
        Person Create(string name, DateTime birthDay);
    }
}
