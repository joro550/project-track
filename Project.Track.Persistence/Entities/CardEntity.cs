using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Track.Persistence.Entities
{
    public class CardEntity : PersistentObject
    {
        public Guid SolutionId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? VersionId { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public List<Guid> Features { get; set; }
            = new();
        
        public override string GetCollectionName(params string[] parameters)
        {
            var solutionId = parameters.First();
            return $"Solution/{solutionId}/Card";
        }

        public override string GetCollectionName() 
            => $"Solution/{SolutionId}/Card";
    }
}