using MediatR;
using Project.Track.Server.Solutions.Models;

namespace Project.Track.Server.Solutions.Commands
{
    public class CreateSolution : IRequest
    {
        public Solution Solution { get; }

        public CreateSolution(Solution solution) 
            => Solution = solution;
    }
}