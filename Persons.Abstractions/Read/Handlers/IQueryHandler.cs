using Persons.Abstractions.Read.Dto;
using Persons.Abstractions.Read.Query;

namespace Persons.Abstractions.Read.Handlers
{
    public interface IQueryHandler // Тут должно быть от базового всего проекта IQueryHandler<TQuery, TResult>
    {
        PersonDto Get(GetPersonByIdQuery getPersonByIdQuery);
    }
}
