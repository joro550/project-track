using System.ComponentModel.DataAnnotations;

namespace Project.Track.Shared.Branches
{
    public class BranchModel
    {
        [Required]
        public string Name { get; set; }
        
        
    }
}