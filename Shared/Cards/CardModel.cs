using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Track.Shared.Cards
{
    public class CardModel
    {
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string State { get; set; }

        public List<string> Features { get; }
            = new();
        
        public string? BranchId { get; set; }
    }
}