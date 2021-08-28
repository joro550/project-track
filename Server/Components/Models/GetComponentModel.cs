using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Components.Models
{
    public record GetComponentModel(string Id, string SolutionId, string Name)
    {
        public static GetComponentModel FromEntity(ComponentEntity entity) 
            => new(entity.Id, entity.SolutionId, entity.Name);
    }

    public record ComponentModel(string Name)
    {
        public ComponentEntity ToEntity(string solutionId)
        {
            return new()
            {
                SolutionId = solutionId,
                Name = Name
            };
        }
    }
}