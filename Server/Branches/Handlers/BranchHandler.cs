using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Project.Track.Persistence;
using Project.Track.Shared.Branches;
using Project.Track.Persistence.Entities;
using Project.Track.Server.Branches.Models;
using Project.Track.Server.Branches.Commands;

namespace Project.Track.Server.Branches.Handlers
{
    public class BranchHandler :
        IRequestHandler<CreateBranch, string>,
        IRequestHandler<GetDefaultBranch, BranchEntity>,
        IRequestHandler<GetBranchById, GetBranchModel?>
    {
        private readonly IRepository<BranchEntity> _branches;

        public BranchHandler(IRepository<BranchEntity> branches) 
            => _branches = branches;

        public async Task<string> Handle(CreateBranch request, CancellationToken cancellationToken)
        {
            var branchEntity = request.GetBranchModel
                .ToEntity(request.ParentBranch, request.SolutionId, request.IsDefaultBranch);
            
            return await _branches.SaveAsync(branchEntity, cancellationToken);;
        }

        public async Task<BranchEntity?> Handle(GetDefaultBranch request, CancellationToken cancellationToken)
        {
            var branch = (await _branches.GetAsync(parameters: request.SolutionId)).FirstOrDefault(entity => entity.IsDefault);
            return branch;
        }

        public async Task<GetBranchModel?> Handle(GetBranchById request, CancellationToken cancellationToken)
        {
            var branch = (await _branches.GetAsync(request.BranchId, request.SolutionId)).FirstOrDefault();
            return branch?.FromEntity();
        }
    }
}