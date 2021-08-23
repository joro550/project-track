using Microsoft.Extensions.DependencyInjection;
using Project.Track.Persistence.Storage;

namespace Project.Track.Persistence.Options
{
    public record InMemoryClientOptions : ClientOptions
    {
        public override void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddTransient(typeof(IStorage<>), typeof(InMemoryStorage<>));
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}