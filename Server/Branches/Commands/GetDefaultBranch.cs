using MediatR;
using Project.Track.Persistence.Entities;

namespace Project.Track.Server.Branches.Commands
{
    public class GetDefaultBranch : IRequest<BranchEntity>
    {
        
    }
}