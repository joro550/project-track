using Project.Track.Persistence.Entities;
using Project.Track.Shared.Cards;

namespace Project.Track.Server.Cards.Models
{
    public static class CardExtensions
    {
        public static GetCardModel ToModel(this CardEntity entity)
            => new()
            {
                Id = entity.Id,
                Description = entity.Description,
                Features = entity.Features,
                State = entity.State,
                Title = entity.Title,
                VersionId = entity.VersionId,
                BranchId = entity.BranchId
            };

        public static CardEntity ToEntity(this CardModel card, string solutionId)
        {
            return new()
            {
                Title = card.Title,
                Description = card.Description,
                State = card.State,
                BranchId = card.BranchId,
                Features = card.Features,
                SolutionId = solutionId
            };
        }
    }
}