using Project.Track.Persistence.Entities;
using Project.Track.Shared.Branches;
using Project.Track.Shared.Cards;

namespace Project.Track.Server.Cards.Models
{
    public static class CardExtensions
    {
        public static GetCardModel ToModel(this CardEntity entity) =>
            new()
            {
                Id = entity.Id,
                Description = entity.Description,
                Features = entity.Features,
                State = entity.State,
                Title = entity.Title,
                VersionId = entity.VersionId,
                BranchName = entity.Branch?.Name
            };

        public static CardEntity ToEntity(this CardModel card, GetBranchModel? branch, string solutionId)
        {
            var cardBranch = branch == null
                ? null
                : new CardEntity.CardBranch { Id = branch.Id, Name = branch.Name };
            
            return new()
            {
                Title = card.Title,
                Description = card.Description,
                State = card.State,
                Features = card.Features,
                SolutionId = solutionId,
                Branch = cardBranch
            };
        }
    }
}