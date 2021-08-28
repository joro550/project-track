using MediatR;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Branches.Commands
{
    public class GetDefaultBranch : IRequest<BranchEntity>
    {
        public GetDefaultBranch(string solutionId)
        {
            SolutionId = solutionId;
        }

        public string SolutionId { get; }
    }
}