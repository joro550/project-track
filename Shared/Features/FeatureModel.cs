using System.ComponentModel.DataAnnotations;

namespace Project.Track.Shared.Features
{
    public class FeatureModel
    {
        [Required]
        public string Name { get; set; }
    }
}