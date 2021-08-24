using System;
using MediatR;

namespace Project.Track.Server.Cards.Commands
{
    public class AssignVersion : INotification
    {
        public Guid BranchId { get; }
        public Guid VersionId { get; }

        public AssignVersion(Guid branchId, Guid versionId)
        {
            BranchId = branchId;
            VersionId = versionId;
        }
    }
}