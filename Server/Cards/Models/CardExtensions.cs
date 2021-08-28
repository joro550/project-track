using Project.Track.Persistence.Entities;
using Project.Track.Shared.Cards;

namespace Project.Track.Server.Cards.Models
{
    public static class CardExtensions
    {
        public static GetCardModel ToModel(this CardEntity entity)
            => new(entity.Id, entity.Title, entity.Description, entity.State, entity.Features, entity.BranchId,
                entity.VersionId);

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