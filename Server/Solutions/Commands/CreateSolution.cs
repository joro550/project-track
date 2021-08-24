using System;
using MediatR;
using Project.Track.Server.Solutions.Models;

namespace Project.Track.Server.Solutions.Commands
{
    public class CreateSolution : IRequest<Guid>
    {
        public SolutionModel GetSolutionModel { get; }

        public CreateSolution(SolutionModel getSolutionModel) 
            => GetSolutionModel = getSolutionModel;
    }
}