using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Branches.Models;
using Project.Track.Server.Branches.Commands;
using Project.Track.Server.Solutions.Commands;

namespace Project.Track.Server.Solutions.Handlers
{
    public class SolutionHandler
        : IRequestHandler<CreateSolution>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<SolutionEntity> _solutions;

        public SolutionHandler(IRepository<SolutionEntity> solutions, IMediator mediator)
        {
            _mediator = mediator;
            _solutions = solutions;
        }
        
        public async Task<Unit> Handle(CreateSolution request, CancellationToken cancellationToken)
        {
            await _solutions.SaveAsync(request.Solution.ToEntity(), cancellationToken);
            await _mediator.Send(new CreateBranch(new Branch(Guid.NewGuid(), request.Solution.Id, "main")), cancellationToken);
            return Unit.Value;
        }
    }
}