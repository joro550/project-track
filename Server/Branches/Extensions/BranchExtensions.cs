using Project.Track.Persistence.Entities;
using Project.Track.Shared.Branches;

namespace Project.Track.Server.Branches.Models
{
    public static class BranchExtensions
    {
        public static BranchEntity ToEntity(this BranchModel model, string? requestParentBranch, string solutionId, bool requestIsDefaultBranch = false)=> new()
        {
            Name = model.Name, 
            SolutionId = solutionId, 
            IsDefault = requestIsDefaultBranch,
            ParentBranch = requestParentBranch
        };
        
        public static GetBranchModel FromEntity(this BranchEntity entity) 
            => new(entity.Id, entity.SolutionId, entity.Name, entity.IsDefault, entity.ParentBranch);
    }
}