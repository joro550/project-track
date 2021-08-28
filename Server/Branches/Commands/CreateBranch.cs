using System;
using MediatR;
using Project.Track.Server.Branches.Models;

namespace Project.Track.Server.Branches.Commands
{
    public class CreateBranch : IRequest<string>
    {
        public BranchModel GetBranchModel { get; }
        public string? ParentBranch { get; }
        public bool IsDefaultBranch { get; }
        public string SolutionId { get; }

        private CreateBranch(BranchModel getBranchModel, string solutionId, string? parentBranch, bool isDefaultBranch = false)
        {
            SolutionId = solutionId;
            ParentBranch = parentBranch;
            GetBranchModel = getBranchModel;
            IsDefaultBranch = isDefaultBranch;
        }

        public static CreateBranch CreateDefaultBranch(string solutionId)
        {
            var branch = new BranchModel("main");
            return new(branch, solutionId, null, true);
        }
    }
}