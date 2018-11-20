using Nancy;
using Persons.Abstractions.Read.Dto;
using Persons.Abstractions.Read.Handlers;
using Persons.Abstractions.Read.Query;
using System;

namespace Persons.Read.Modules
{
    public class GetPersonModule : NancyModule
    {
        public GetPersonModule(IQueryHandler queryHandler)
        {
            Get(Consts.BASE_PREFIX_V1 + "/{person_id}", x => {

                var id = Guid.Parse(x.person_id);

                var query = new GetPersonByIdQuery { Id = id };

                var result = queryHandler.Get(query);

                return Map(result);
            });
        }

        private Response Map(PersonDto personDto)
        {
            var result = Response.AsJson(personDto);

            if (personDto == null)
                result.StatusCode = HttpStatusCode.NotFound;

            return result;
        }
    }
}
