using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Solutions.Models
{
    public record Solution(Guid Id, string Name)
    {
        public SolutionEntity ToEntity() 
            => new() { Id = Id, Name = Name };
    }
}