using System;

namespace Project.Track.Persistence.Entities
{
    public class SolutionEntity : PersistentObject
    {
        public string Name { get; set; }

        public override string GetCollectionName(params string[] parameters) 
            => GetCollectionName();

        public override string GetCollectionName() 
            => "Solutions";
    }
}