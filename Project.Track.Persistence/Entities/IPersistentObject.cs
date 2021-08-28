using System;

namespace Project.Track.Persistence.Entities
{
    public interface IPersistentObject
    {
        public string Id { get; set; }
    }
}