using MediatR;
using Project.Track.Server.Branches.Models;

namespace Project.Track.Server.Branches.Commands
{
    public class CreateBranch : IRequest
    {
        public Branch Branch { get; }

        public CreateBranch(Branch branch) 
            => Branch = branch;
    }
}