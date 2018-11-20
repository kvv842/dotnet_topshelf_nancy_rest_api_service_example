using Nancy.Hosting.Self;
using System;
using Topshelf.Logging;

namespace Persons
{
    public class NancySelfHost
    {
        private NancyHost _nancyHost;

        private static readonly LogWriter _log = HostLogger.Get<NancySelfHost>();

        public void Start()
        {
            var hostConfigs = new HostConfiguration
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            _nancyHost = new NancyHost(hostConfigs, new Uri(Consts.HOSTNAME));
            _nancyHost.Start();
        }

        public void Stop()
        {
            _nancyHost.Stop();
        }
    }
}
