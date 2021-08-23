using Microsoft.Extensions.DependencyInjection;

namespace Project.Track.Persistence.Options
{
    public abstract record ClientOptions
    {
        public abstract void AddServices(IServiceCollection serviceCollection);
    }
}