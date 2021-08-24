using System;
using System.Collections.Generic;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Cards.Models
{
    public record GetCardModel(Guid Id, string Title, string Description, string State,
        List<Guid> Features, Guid? BranchId, Guid? VersionId)
    {
        public static GetCardModel FromEntity(CardEntity entity)
        {
            return new(entity.Id, entity.Title, entity.Description, entity.State,
                entity.Features, entity.BranchId, entity.VersionId);
        }
    }
}