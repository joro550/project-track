using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Branches.Models
{
    public record BranchModel(string Name)
    {
        public BranchEntity ToBranch(string? requestParentBranch, string solutionId, bool requestIsDefaultBranch = false)
            => new()
            {
                Name = Name, 
                SolutionId = solutionId, 
                IsDefault = requestIsDefaultBranch,
                ParentBranch = requestParentBranch
            };
        
    }
}