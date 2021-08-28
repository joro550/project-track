using Google.Cloud.Firestore;

namespace Project.Track.Persistence.Entities
{
    [FirestoreData]
    public abstract class PersistentObject : IPersistentObject
    {
        [FirestoreDocumentId]
        public string Id { get; set; }

        public abstract string GetCollectionName(params string[] parameters);
        public abstract string GetCollectionName();
    }
}