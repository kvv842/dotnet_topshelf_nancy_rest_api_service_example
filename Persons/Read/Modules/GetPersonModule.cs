using Nancy;
using Persons.Abstractions.Read.Dto;
using Persons.Abstractions.Read.Handlers;
using Persons.Abstractions.Read.Query;
using Persons.Exceptions;
using System;

namespace Persons.Read.Modules
{
    public class GetPersonModule : NancyModule
    {
        public GetPersonModule(IQueryHandler queryHandler)
        {
            Get(Consts.BASE_PREFIX_V1 + "/{person_id}", x => {

                if (Guid.TryParse(x.person_id, out Guid id))
                {

                    var query = new GetPersonByIdQuery { Id = id };

                    var result = queryHandler.Get(query);

                    return Map(result);
                }
                else
                    throw new BadRequestException($"Bad param person_id");
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
