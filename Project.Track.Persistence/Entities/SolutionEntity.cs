using System;
using Google.Cloud.Firestore;

namespace Project.Track.Persistence.Entities
{
    [FirestoreData]
    public class SolutionEntity : PersistentObject
    {
        [FirestoreProperty]
        public string Name { get; set; }

        public override string GetCollectionName(params string[] parameters) 
            => GetCollectionName();

        public override string GetCollectionName() 
            => "Solutions";
    }
}