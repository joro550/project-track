using System.ComponentModel.DataAnnotations;

namespace Project.Track.Shared.Solutions
{
    public class SolutionModel
    {
        [Required]
        public string Name { get; set; }
    }
}