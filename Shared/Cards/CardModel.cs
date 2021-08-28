using System.Collections.Generic;

namespace Project.Track.Shared.Cards
{
    public record CardModel(string Title, string Description, string State,
        List<string> Features, string? BranchId)
    {
    }
}