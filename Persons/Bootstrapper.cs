using Nancy;
using Persons.Abstractions.Read.Handlers;
using Persons.Abstractions.Write.Handlers;
using Persons.Read.Handlers;
using Persons.Service.Read.InfrastructureLayer;
using Persons.Service.Write.ApplicationLayer;
using Persons.Service.Write.InfrastructureLayer;
using Persons.Write.Handlers;
using System.Configuration;

namespace Persons
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            var readDBConnectionString = ConfigurationManager.ConnectionStrings["ReadDB"].ConnectionString;
            var writeDBConnectionString = ConfigurationManager.ConnectionStrings["WriteDB"].ConnectionString;

            base.ApplicationStartup(container, pipelines);
            container.Register<IQueryHandler, PersonsQueryHandler>();
            container.Register<IReadRepository>(new ReadRepository(readDBConnectionString));

            container.Register<ICommandHandler, CommandHandler>();
            container.Register<IWriteRepository>(new WriteRepository(writeDBConnectionString));
            container.Register<IPersonService, PersonService>();
        }
    }
}
