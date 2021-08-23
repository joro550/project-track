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
            var branchEntity = request.Branch.ToBranch(request.ParentBranch, request.IsDefaultBranch);
            await _branches.SaveAsync(branchEntity, cancellationToken);
            return Unit.Value;
        }
    }
}