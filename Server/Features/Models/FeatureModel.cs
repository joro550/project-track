using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Features.Models
{
    public record FeatureModel(string Name)
    {
        public FeatureEntity ToEntity(string solutionId) =>
            new()
            {
                Name = Name, 
                SolutionId = solutionId
            };
    }
}