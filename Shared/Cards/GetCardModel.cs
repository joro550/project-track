using System.Collections.Generic;

namespace Project.Track.Shared.Cards
{
    public class GetCardModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public List<string> Features { get; set; }
            = new();
        public string? BranchName { get; set; }
        public string VersionId { get; set; }
    }
}