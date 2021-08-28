using System;
using System.Collections.Generic;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Cards.Models
{
    public record CardModel(string Title, string Description, string State,
        List<string> Features, string? BranchId)
    {
        public CardEntity ToEntity(string solutionId) =>
            new()
            {
                Title = Title,
                Description = Description,
                State = State,
                SolutionId = solutionId,
                Features = Features,
                BranchId = BranchId
            };
    }
}