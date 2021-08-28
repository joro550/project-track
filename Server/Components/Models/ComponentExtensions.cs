using Project.Track.Persistence.Entities;
using Project.Track.Shared.Components;

namespace Project.Track.Server.Components.Models
{
    public static class ComponentExtensions
    {
        public static GetComponentModel FromEntity(this ComponentEntity entity)
            => new(entity.Id, entity.SolutionId, entity.Name, entity.FeatureId);

        public static ComponentEntity ToEntity(this ComponentModel model, string solutionId) =>
            new()
            {
                Name = model.Name,
                SolutionId = solutionId,
                FeatureId = model.FeatureId
            };
    }
}