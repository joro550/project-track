using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Branches.Models
{
    public record Branch(Guid Id, Guid ProjectId, string Name)
    {
        public BranchEntity ToBranch() 
            => new() { Id = Id, SolutionId = ProjectId, Name = Name };
    }
}