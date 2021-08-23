using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Branches.Commands;

namespace Project.Track.Server.Branches.Handlers
{
    public class BranchHandler
        :IRequestHandler<CreateBranch>
    {
        private readonly IRepository<BranchEntity> _branches;

        public BranchHandler(IRepository<BranchEntity> branches) 
            => _branches = branches;

        public async Task<Unit> Handle(CreateBranch request, CancellationToken cancellationToken)
        {
            await _branches.SaveAsync(request.Branch.ToBranch(), cancellationToken);
            return Unit.Value;
        }
    }
}