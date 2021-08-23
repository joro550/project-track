using System;
using MediatR;
using Project.Track.Server.Branches.Models;

namespace Project.Track.Server.Branches.Commands
{
    public class CreateBranch : IRequest
    {
        public Branch Branch { get; }
        public Guid? ParentBranch { get; }
        public bool IsDefaultBranch { get; }
        
        public CreateBranch(Branch branch, Guid? parentBranch, bool isDefaultBranch = false)
        {
            Branch = branch;
            ParentBranch = parentBranch;
            IsDefaultBranch = isDefaultBranch;
        }

        public static CreateBranch CreateDefaultBranch(Guid solutionId)
        {
            var branch = new Branch(Guid.NewGuid(), solutionId, "main");
            return new(branch, null, true);
        }
    }
}