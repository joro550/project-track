using System.Collections.Generic;

namespace Project.Track.Shared.Cards
{
    public record GetCardModel(string Id, string Title, string Description, string State,
        List<string> Features, string? BranchId, string? VersionId)
    {
    }
}