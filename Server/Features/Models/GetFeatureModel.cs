using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Features.Models
{
    public record GetFeatureModel(Guid Id, string Name, Guid SolutionId)
        : FeatureModel (Name)
    {
        public static GetFeatureModel FromEntity(FeatureEntity entity) 
            => new(entity.Id, entity.Name, entity.SolutionId);
    }
}