using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Branches.Models
{
    public record Branch(Guid Id, Guid SolutionId, string Name)
    {
        public BranchEntity ToBranch(Guid? requestParentBranch, bool requestIsDefaultBranch = false)
            => new()
            {
                Id = Id,
                Name = Name, 
                SolutionId = SolutionId, 
                IsDefault = requestIsDefaultBranch,
                ParentBranch = requestParentBranch
            };
    }
}