using Serilog;
using Topshelf;
using Topshelf.LibLog;

namespace Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            HostFactory.Run(x =>
            {
                //x.UseLinuxIfAvailable();
                x.UseLibLog();
                x.Service<NancySelfHost>(s =>
                {
                    s.ConstructUsing(name => new NancySelfHost());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDescription("Persons-Nancy-SelfHost REST API service");
                x.SetDisplayName("Persons-Nancy-SelfHost Service");
                x.SetServiceName("Persons-Nancy-SelfHost");
            });
        }
    }
}
