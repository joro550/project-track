using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Project.Track.Persistence;
using Project.Track.Server.Cards.Models;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Cards.Commands;
using Project.Track.Server.Branches.Commands;

namespace Project.Track.Server.Cards.Handlers
{
    public class CardHandler :
        INotificationHandler<AssignVersion>,
        INotificationHandler<UpdateBranchName>,
        IRequestHandler<CreateCard, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<CardEntity> _cards;

        public CardHandler(IRepository<CardEntity> cards, IMediator mediator)
        {
            _cards = cards;
            _mediator = mediator;
        }

        public async Task Handle(AssignVersion notification, CancellationToken cancellationToken)
        {
            var cards = (await _cards.GetAsync(parameters: notification.SolutionId))
                .Where(e => e.Branch != null && e.Branch.Id == notification.BranchId)
                .ToList();
            
            if(!cards.Any())
                return;

            foreach (var entity in cards)
            {
                entity.VersionId = notification.VersionId;
                await _cards.SaveAsync(entity, cancellationToken);
            }
        }

        public async Task Handle(UpdateBranchName notification, CancellationToken cancellationToken)
        {
            var cards = (await _cards.GetAsync(parameters: notification.SolutionId))
                .Where(e => e.Branch != null && e.Branch.Id == notification.BranchId)
                .ToList();
            
            if(!cards.Any())
                return;

            foreach (var entity in cards.Where(e => e.Branch != null))
            {
                entity.Branch!.Name = notification.NewBranchName;
                await _cards.SaveAsync(entity, cancellationToken);
            }
        }

        public async Task<string> Handle(CreateCard request, CancellationToken cancellationToken)
        {
            var branch = await _mediator.Send(new GetBranchById(request.SolutionId, request.Card.BranchId), cancellationToken);
            var cardEntity = request.Card.ToEntity(branch, request.SolutionId);
            return await _cards.SaveAsync(cardEntity, cancellationToken);
        }
    }
}