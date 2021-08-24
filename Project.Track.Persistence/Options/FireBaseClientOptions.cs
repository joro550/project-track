using Microsoft.Extensions.DependencyInjection;

namespace Project.Track.Persistence.Options
{
    public record FireBaseClientOptions(string Url) : ClientOptions
    {
        public override void AddServices(IServiceCollection serviceCollection)
        {
            
        }
    }
}