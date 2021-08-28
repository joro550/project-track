using System;
using System.Linq;
using Google.Cloud.Firestore;

namespace Project.Track.Persistence.Entities
{
    [FirestoreData]
    public class VersionEntity : PersistentObject
    {
        [FirestoreProperty]
        public string SolutionId { get; set; }
        
        [FirestoreProperty]
        public string Name { get; set; }
        
        public override string GetCollectionName(params string[] parameters)
        {
            var solutionId = parameters.First();
            return $"Solutions/{solutionId}/Versions";
        }

        public override string GetCollectionName() 
            =>  GetCollectionName(SolutionId);
    }
}