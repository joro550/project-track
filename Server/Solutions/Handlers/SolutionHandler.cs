using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Branches.Commands;
using Project.Track.Server.Solutions.Commands;
using Project.Track.Server.Solutions.Extensions;

namespace Project.Track.Server.Solutions.Handlers
{
    public class SolutionHandler
        : IRequestHandler<CreateSolution, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<SolutionEntity> _solutions;

        public SolutionHandler(IRepository<SolutionEntity> solutions, IMediator mediator)
        {
            _mediator = mediator;
            _solutions = solutions;
        }
        
        public async Task<string> Handle(CreateSolution request, CancellationToken cancellationToken)
        {
            var solutionId = await _solutions.SaveAsync(request.GetSolutionModel.ToEntity(), cancellationToken);
            await _mediator.Send(CreateBranch.CreateDefaultBranch(solutionId), cancellationToken);
            return solutionId;
        }
    }
}