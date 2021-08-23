using System;

namespace Project.Track.Persistence
{
    public interface IPersistentObject
    {
        public Guid Id { get; set; }
    }
}