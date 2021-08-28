using Google.Api.Gax;
using Google.Cloud.Firestore;
using Project.Track.Persistence.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Project.Track.Persistence.Options
{
    public record FireBaseClientOptions(string ProjectId) : ClientOptions
    {
        public override void AddServices(IServiceCollection serviceCollection)
        {
            var firestoreDbBuilder = new FirestoreDbBuilder
            {
                ProjectId = ProjectId,
                EmulatorDetection = EmulatorDetection.EmulatorOnly
            };
            
            serviceCollection.TryAddSingleton(firestoreDbBuilder.Build());
            serviceCollection.AddTransient(typeof(IStorage<>), typeof(FireStore<>));
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}