using System;
using MediatR;

namespace Project.Track.Server.Cards.Commands
{
    public class AssignVersion : INotification
    {
        public string SolutionId { get; }
        public string BranchId { get; }
        public string VersionId { get; }

        public AssignVersion(string branchId, string versionId, string solutionId)
        {
            BranchId = branchId;
            VersionId = versionId;
            SolutionId = solutionId;
        }
    }
}