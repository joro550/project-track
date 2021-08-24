using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Solutions.Models
{
    public record GetSolutionModel(Guid Id, string Name) 
        : SolutionModel(Name)
    {
        public override SolutionEntity ToEntity() 
            => new() { Id = Id, Name = Name };

        public static GetSolutionModel FromEntity(SolutionEntity entity) 
            => new(entity.Id, entity.Name);
    }
}