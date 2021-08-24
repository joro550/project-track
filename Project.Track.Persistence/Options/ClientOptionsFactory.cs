namespace Project.Track.Persistence.Options
{
    public class ClientOptionsFactory
    {
        public FireBaseClientOptions UseFirebase(string url) 
            => new(url);
        
        public InMemoryClientOptions UseInMemoryStore() 
            => new();
    }
}