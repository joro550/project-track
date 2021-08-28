using Project.Track.Persistence.Entities;
using Project.Track.Shared.Features;

namespace Project.Track.Server.Features.Models
{
    public static class FeatureExtensions
    {
        public static GetFeatureModel FromEntity(this FeatureEntity entity) 
            => new(entity.Id, entity.Name, entity.SolutionId);

        public static FeatureEntity ToEntity(this FeatureModel model, string solutionId) =>
            new()
            {
                Name = model.Name,
                SolutionId = solutionId
            };
    }
}