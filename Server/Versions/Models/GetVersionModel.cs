using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Versions.Models
{
    public record GetVersionModel(Guid Id, string Name, Guid SolutionId)
        : VersionModel(Name)
    {
        public static GetVersionModel FromEntity(VersionEntity entity)
        {
            return new(entity.Id, entity.Name, entity.SolutionId);
        }
    }
}