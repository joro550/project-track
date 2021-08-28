namespace Project.Track.Persistence.Options
{
    public class ClientOptionsFactory
    {
        public FireBaseClientOptions UseFirebase(string projectId) 
            => new(projectId);
        
        public InMemoryClientOptions UseInMemoryStore() 
            => new();
    }
}