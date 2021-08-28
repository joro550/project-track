using System;
using MediatR;

namespace Project.Track.Server.Versions.Commands
{
    public class CreateVersion : IRequest<string>
    {
        public string Name { get; }
        public string SolutionId { get; }

        public CreateVersion(string name, string solutionId)
        {
            Name = name;
            SolutionId = solutionId;
        }
    }
}