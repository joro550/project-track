using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Cards.Commands;

namespace Project.Track.Server.Cards.Handlers
{
    public class CardHandler :
        INotificationHandler<AssignVersion>
    {
        private readonly IRepository<CardEntity> _cards;

        public CardHandler(IRepository<CardEntity> cards) 
            => _cards = cards;

        public async Task Handle(AssignVersion notification, CancellationToken cancellationToken)
        {
            var cards = (await _cards.GetAsync(cancellationToken))
                .Where(e => e.BranchId == notification.BranchId)
                .ToList();
            
            if(!cards.Any())
                return;

            foreach (var entity in cards)
            {
                entity.VersionId = notification.VersionId;
                await _cards.SaveAsync(entity, cancellationToken);
            }
        }
    }
}