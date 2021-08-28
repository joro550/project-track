using System;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Versions.Models
{
    public record GetVersionModel(string Id, string Name, string SolutionId)
        : VersionModel(Name)
    {
        public static GetVersionModel FromEntity(VersionEntity entity)
        {
            return new(entity.Id, entity.Name, entity.SolutionId);
        }
    }
}