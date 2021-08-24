using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Branches.Models
{
    public record BranchModel(string Name)
    {
        public BranchEntity ToBranch(Guid? requestParentBranch, Guid solutionId, bool requestIsDefaultBranch = false)
            => new()
            {
                Name = Name, 
                SolutionId = solutionId, 
                IsDefault = requestIsDefaultBranch,
                ParentBranch = requestParentBranch
            };
        
    }
}