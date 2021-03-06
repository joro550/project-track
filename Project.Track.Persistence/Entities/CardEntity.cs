using System;
using System.Collections.Generic;
using System.Linq;
using Google.Cloud.Firestore;

namespace Project.Track.Persistence.Entities
{
    [FirestoreData]
    public class CardEntity : PersistentObject
    {
        public class CardBranch
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        
        [FirestoreProperty]
        public string SolutionId { get; set; }
        
        [FirestoreProperty]
        public CardBranch? Branch { get; set; }
        
        [FirestoreProperty]
        public string? VersionId { get; set; }
        
        [FirestoreProperty]
        public string Title { get; set; }
        
        [FirestoreProperty]
        public string Description { get; set; }
        
        [FirestoreProperty]
        public string State { get; set; }
        
        [FirestoreProperty]
        public List<string> Features { get; set; }
            = new();
        
        public override string GetCollectionName(params string[] parameters)
        {
            var solutionId = parameters.First();
            return $"Solutions/{solutionId}/Cards";
        }

        public override string GetCollectionName() 
            =>  GetCollectionName(SolutionId);
    }
}