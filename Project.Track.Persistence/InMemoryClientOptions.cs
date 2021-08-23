using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Project.Track.Persistence
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

    internal class Repository<T> : IRepository<T> where T : PersistentObject
    {
    }

    internal class InMemoryStorage<T> : IStorage<T> where T : PersistentObject
    {
        private IMemoryCache _memoryCache;

        public InMemoryStorage(IMemoryCache memoryCache) 
            => _memoryCache = memoryCache;
    }

    internal interface IStorage<T> where T : PersistentObject
    {
    }
}