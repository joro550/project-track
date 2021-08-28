using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Project.Track.Persistence.Entities;

namespace Project.Track.Persistence.Storage
{
    internal class FireStore<T> : IStorage<T> where T : PersistentObject, new()
    {
        private readonly FirestoreDb _firestoreDb;

        public FireStore(FirestoreDb firestoreDb) 
            => _firestoreDb = firestoreDb;

        public async Task<string> SaveAsync(T model)
        {
            var collection = _firestoreDb.Collection(model.GetCollectionName());
            var identifier = await collection.AddAsync(model);
            return identifier.Id;
        }

        public async Task<List<T>> GetAsync(params string[] @params)
        {
            var model = new T();
            var collection = _firestoreDb.Collection(model.GetCollectionName(@params));
            var snapshot = await collection.GetSnapshotAsync();
            if (!snapshot.Any())
                return new List<T>();
            
            return snapshot.Select(document => document.ConvertTo<T>()).ToList();
        }

        public async Task<List<T>> GetAsync(string id, params string[] @params)
        {
            var model = new T();
            var collection = _firestoreDb.Collection(model.GetCollectionName(@params));
            var documents = await collection.Document(id).GetSnapshotAsync();

            return documents.Exists 
                ? new List<T> { documents.ConvertTo<T>() } 
                : new List<T>();
        }
    }
}