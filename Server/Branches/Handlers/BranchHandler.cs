using System;
using System.Linq;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Project.Track.Persistence;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Branches.Commands;

namespace Project.Track.Server.Branches.Handlers
{
    public class BranchHandler :
        IRequestHandler<CreateBranch, Guid>,
        IRequestHandler<GetDefaultBranch, BranchEntity>
    {
        private readonly IRepository<BranchEntity> _branches;

        public BranchHandler(IRepository<BranchEntity> branches) 
            => _branches = branches;

        public async Task<Guid> Handle(CreateBranch request, CancellationToken cancellationToken)
        {
            var branchEntity = request.GetBranchModel
                .ToBranch(request.ParentBranch, request.SolutionId, request.IsDefaultBranch);
            
            return await _branches.SaveAsync(branchEntity, cancellationToken);;
        }

        public async Task<BranchEntity> Handle(GetDefaultBranch request, CancellationToken cancellationToken)
        {
            var branch = (await _branches.GetAsync(cancellationToken)).FirstOrDefault(entity => entity.IsDefault);
            return branch;
        }
    }
}