using System;
using System.Linq;

namespace Project.Track.Persistence.Entities
{
    public class ComponentEntity : PersistentObject
    {
        public Guid SolutionId { get; set; }
        public string Name { get; set; }
        
        public override string GetCollectionName(params string[] parameters)
        {
            var solutionId = parameters.First();
            return $"Solution/{solutionId}/Component";
        }

        public override string GetCollectionName() 
            => $"Solution/{SolutionId}/Component";
    }
}