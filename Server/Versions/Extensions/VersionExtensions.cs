using Project.Track.Persistence.Entities;
using Project.Track.Server.Versions.Commands;
using Project.Track.Shared.Versions;

namespace Project.Track.Server.Versions.Models
{
    public static class VersionExtensions
    {
        public static GetVersionModel FromEntity(this VersionEntity entity) 
            => new(entity.Id, entity.Name, entity.SolutionId);

        public static VersionEntity ToEntity(this VersionModel model, string solutionId) 
            => new() { Name = model.Name, SolutionId = solutionId };
        
        
        public static CreateVersion ToRequest(this VersionModel model,string solutionId) 
            => new(model.Name, solutionId);
    }
}