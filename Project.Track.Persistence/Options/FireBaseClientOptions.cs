using Microsoft.Extensions.DependencyInjection;
using Project.Track.Persistence.Options;

namespace Project.Track.Persistence
{
    public record FireBaseClientOptions(string Url) : ClientOptions
    {
        public override void AddServices(IServiceCollection serviceCollection)
        {
            
        }
    }
}