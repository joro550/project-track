using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Branches.Models
{
    public record GetBranchModel(string Id, string SolutionId, string Name, bool IsDefaultBranch, string? ParentBranch) 
        : BranchModel(Name)
    {
        public static GetBranchModel FromEntity(BranchEntity entity) 
            => new(entity.Id, entity.SolutionId, entity.Name, entity.IsDefault, entity.ParentBranch);
    }
}