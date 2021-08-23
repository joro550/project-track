using Project.Track.Persistence.Options;

namespace Project.Track.Persistence
{
    public class ClientOptionsFactory
    {
        public FireBaseClientOptions UseFirebase(string url) 
            => new(url);
        
        public InMemoryClientOptions UseInMemoryStore() 
            => new();
    }
}