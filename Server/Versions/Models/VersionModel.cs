using System;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Versions.Commands;

namespace Project.Track.Server.Versions.Models
{
    public record VersionModel(string Name)
    {
        public VersionEntity ToEntity(string solutionId) =>
            new()
            {
                Name = Name,
                SolutionId = solutionId
            };

        public CreateVersion ToRequest(string solutionId) 
            => new(Name, solutionId);
    }
}