using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Components.Models
{
    public record GetComponentModel(Guid Id, Guid SolutionId, string Name)
    {
        public static GetComponentModel FromEntity(ComponentEntity entity) 
            => new(entity.Id, entity.SolutionId, entity.Name);
    }

    public record ComponentModel(string Name)
    {
        public ComponentEntity ToEntity(Guid solutionId)
        {
            return new()
            {
                SolutionId = solutionId,
                Name = Name
            };
        }
    }
}