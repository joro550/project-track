using MediatR;

namespace Project.Track.Server.Branches.Commands
{
    public class UpdateBranchName : INotification
    {
        public string BranchId { get; }
        public string SolutionId { get; }
        public string NewBranchName { get; }

        public UpdateBranchName(string branchId, string solutionId, string newBranchName)
        {
            BranchId = branchId;
            SolutionId = solutionId;
            NewBranchName = newBranchName;
        }
    }
}