using System.ComponentModel.DataAnnotations;

namespace Project.Track.Shared.Components
{
    public class ComponentModel
    {
        [Required]
        public string Name { get; set; }
    }
}