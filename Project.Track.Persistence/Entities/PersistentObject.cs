using System;

namespace Project.Track.Persistence
{
    public abstract class PersistentObject : IPersistentObject
    {
        public Guid Id { get; set; }

        public abstract string GetCollectionName(params string[] parameters);
        public abstract string GetCollectionName();
    }
}