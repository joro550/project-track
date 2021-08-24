using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Branches.Models
{
    public record GetBranchModel(Guid Id, Guid SolutionId, string Name, bool IsDefaultBranch, Guid? ParentBranch) 
        : BranchModel(Name)
    {
        public static GetBranchModel FromEntity(BranchEntity entity) 
            => new(entity.Id, entity.SolutionId, entity.Name, entity.IsDefault, entity.ParentBranch);
    }
}