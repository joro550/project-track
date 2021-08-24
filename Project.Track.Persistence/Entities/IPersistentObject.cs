using System;

namespace Project.Track.Persistence.Entities
{
    public interface IPersistentObject
    {
        public Guid Id { get; set; }
    }
}