using System.ComponentModel.DataAnnotations;

namespace Project.Track.Shared.Versions
{
    public class VersionModel
    {
        
        [Required]
        public string Name { get; set; }
    }
}