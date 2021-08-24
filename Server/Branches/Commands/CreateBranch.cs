using System;
using MediatR;
using Project.Track.Server.Branches.Models;

namespace Project.Track.Server.Branches.Commands
{
    public class CreateBranch : IRequest<Guid>
    {
        public BranchModel GetBranchModel { get; }
        public Guid? ParentBranch { get; }
        public bool IsDefaultBranch { get; }
        public Guid SolutionId { get; }

        private CreateBranch(BranchModel getBranchModel, Guid solutionId, Guid? parentBranch, bool isDefaultBranch = false)
        {
            SolutionId = solutionId;
            ParentBranch = parentBranch;
            GetBranchModel = getBranchModel;
            IsDefaultBranch = isDefaultBranch;
        }

        public static CreateBranch CreateDefaultBranch(Guid solutionId)
        {
            var branch = new BranchModel("main");
            return new(branch, solutionId, null, true);
        }
    }
}