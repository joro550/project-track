using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Solutions.Models
{
    public record SolutionModel(string Name)
    {
        public virtual SolutionEntity ToEntity() 
            => new() { Name = Name };
    }
}