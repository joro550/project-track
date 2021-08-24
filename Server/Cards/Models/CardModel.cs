using System;
using System.Collections.Generic;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Cards.Models
{
    public record CardModel(string Title, string Description, string State,
        List<Guid> Features, Guid? BranchId)
    {
        public CardEntity ToEntity(Guid solutionId) =>
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