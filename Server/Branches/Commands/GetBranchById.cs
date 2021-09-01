using MediatR;
using Project.Track.Shared.Branches;

namespace Project.Track.Server.Branches.Commands
{
    public class GetBranchById : IRequest<GetBranchModel?>
    {
        public GetBranchById(string solutionId, string branchId)
        {
            BranchId = branchId;
            SolutionId = solutionId;
        }

        public string BranchId { get; }
        public string SolutionId { get; }
    }
}