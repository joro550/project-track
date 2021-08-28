using MediatR;
using Project.Track.Shared.Solutions;

namespace Project.Track.Server.Solutions.Commands
{
    public class CreateSolution : IRequest<string>
    {
        public SolutionModel GetSolutionModel { get; }

        public CreateSolution(SolutionModel getSolutionModel) 
            => GetSolutionModel = getSolutionModel;
    }
}