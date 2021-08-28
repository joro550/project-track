using Project.Track.Persistence.Entities;
using Project.Track.Shared.Solutions;

namespace Project.Track.Server.Solutions.Extensions
{
    // public record SolutionModel(string Name)
    // {
    //     public virtual SolutionEntity ToEntity() 
    //         => new() { Name = Name };
    // }

    public static class SolutionModelExtensions
    {
        public static SolutionEntity ToEntity(this SolutionModel solutionModel) 
            => new SolutionEntity { Name = solutionModel.Name };

        public static GetSolutionModel ToModel(this SolutionEntity solutionEntity) 
            => new GetSolutionModel(solutionEntity.Id, solutionEntity.Name);
    }
}