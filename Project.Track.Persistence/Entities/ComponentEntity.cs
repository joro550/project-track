using System;
using System.Linq;

namespace Project.Track.Persistence.Entities
{
    public class ComponentEntity : PersistentObject
    {
        public string SolutionId { get; set; }
        public string Name { get; set; }
        public string FeatureId { get; set; }
        
        public override string GetCollectionName(params string[] parameters)
        {
            var solutionId = parameters.First();
            return $"Solutions/{solutionId}/Component";
        }

        public override string GetCollectionName()
            => GetCollectionName(SolutionId);
    }
}