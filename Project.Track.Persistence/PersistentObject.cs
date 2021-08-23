using System;

namespace Project.Track.Persistence
{
    internal abstract class PersistentObject : IPersistentObject
    {
        public Guid Id { get; set; }

        public abstract string GetCollectionName(params string[] parameters);
    }
}