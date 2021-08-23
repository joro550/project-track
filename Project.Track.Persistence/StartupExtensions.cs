using System;
using Microsoft.Extensions.DependencyInjection;
using Project.Track.Persistence.Options;

namespace Project.Track.Persistence
{
    public static class StartupExtensions
    {
        public static void AddClient(this IServiceCollection serviceCollection, Func<ClientOptionsFactory, ClientOptions> createClientOptions)
        {
            var options = createClientOptions(new ClientOptionsFactory());
            options.AddServices(serviceCollection);
        }
        
    }
}