using Nancy;
using Newtonsoft.Json;
using Persons.Abstractions.Write.Commands;
using Persons.Abstractions.Write.Handlers;
using Persons.Exceptions;
using System.IO;

namespace Persons.Read.Modules
{
    public class CreatePersonModule : NancyModule
    {
        public CreatePersonModule(ICommandHandler cammandHandler)
        {
            Post(Consts.BASE_PREFIX_V1, x =>
            {
                CreatePersonCommand createPersonCommand = null;
                try
                {
                    createPersonCommand = GetRequest<CreatePersonCommand>();
                }
                catch { }

                if (createPersonCommand == null)
                    throw new BadRequestException("It is impossible to create a command.");

                var result = cammandHandler.Handle(createPersonCommand);

                return new Response() { StatusCode = HttpStatusCode.Created }
                .WithHeader("Location", $"{Consts.BASE_PREFIX_V1}/{result.ToString()}");
            });
        }

        private T GetRequest<T>()
        {
            using (var streamReader = new StreamReader(Request.Body))
            {
                var jsonTextReader = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(jsonTextReader);
            }
        }
    }
}
