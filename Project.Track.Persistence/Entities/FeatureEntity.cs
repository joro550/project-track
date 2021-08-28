using System;
using System.Linq;
using Google.Cloud.Firestore;

namespace Project.Track.Persistence.Entities
{
    [FirestoreData]
    public class FeatureEntity : PersistentObject
    {
        [FirestoreProperty]
        public string SolutionId { get; set; }
        
        [FirestoreProperty]
        public string Name { get; set; }
        
        // public Guid ComponentId { get; set; }
        
        public override string GetCollectionName(params string[] parameters)
        {
            var solutionId = parameters.First();
            return $"Solutions/{solutionId}/Features";
        }

        public override string GetCollectionName() 
            =>  GetCollectionName(SolutionId);
    }
}