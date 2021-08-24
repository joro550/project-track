using System;
using MediatR;

namespace Project.Track.Server.Versions.Commands
{
    public class CreateVersion : IRequest<Guid>
    {
        public string Name { get; }
        public Guid SolutionId { get; }

        public CreateVersion(string name, Guid solutionId)
        {
            Name = name;
            SolutionId = solutionId;
        }
    }
}