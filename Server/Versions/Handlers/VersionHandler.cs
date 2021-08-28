using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Cards.Commands;
using Project.Track.Server.Branches.Commands;
using Project.Track.Server.Versions.Commands;

namespace Project.Track.Server.Versions.Handlers
{
    public class VersionHandler :
        IRequestHandler<CreateVersion, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<VersionEntity> _versions;

        public VersionHandler(IRepository<VersionEntity> versions, IMediator mediator)
        {
            _versions = versions;
            _mediator = mediator;
        }

        public async Task<string> Handle(CreateVersion request, CancellationToken cancellationToken)
        {
            var versionId = await _versions.SaveAsync(new VersionEntity { Name = request.Name, SolutionId = request.SolutionId },
                cancellationToken);
            
            var defaultBranchId = await _mediator.Send(new GetDefaultBranch(request.SolutionId), cancellationToken);
            await _mediator.Publish(new AssignVersion(defaultBranchId.Id, versionId, request.SolutionId), cancellationToken);
            return versionId;
        }
    }
}