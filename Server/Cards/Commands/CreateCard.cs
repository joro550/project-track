using MediatR;
using Project.Track.Shared.Cards;

namespace Project.Track.Server.Cards.Commands
{
    public class CreateCard : IRequest<string>
    {
        public CardModel Card { get; }
        public string SolutionId { get; }

        public CreateCard(CardModel model, string solutionId)
        {
            SolutionId = solutionId;
            Card = model;
        }
    }
}