using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Project.Track.Persistence.Entities;

namespace Project.Track.Persistence.Storage
{
    /// <summary>
    /// Please don't look at this implementation, this is horrible
    /// </summary>
    internal class InMemoryStorage<T> : IStorage<T> where T : PersistentObject, new()
    {
        private readonly IMemoryCache _memoryCache;
        private readonly string _typeName = typeof(T).Name;

        public InMemoryStorage(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        public async Task<Guid> SaveAsync(T model)
        {
            var persistentObjects = new Dictionary<string, T>();

            if (_memoryCache.TryGetValue(_typeName, out Dictionary<string, T> modelFromStore))
                persistentObjects = modelFromStore;
            var collectionName = model.GetCollectionName();
            if (persistentObjects.ContainsKey($"{collectionName}/{model.Id.ToString()}"))
                persistentObjects[$"{collectionName}/{model.Id.ToString()}"] = model;
            else
            {
                model.Id = Guid.NewGuid();
                persistentObjects.Add($"{collectionName}/{model.Id.ToString()}", model);
            }

            _memoryCache.Set(_typeName, persistentObjects);
            return model.Id;
        }

        public async Task<List<T>> GetAsync()
        {
            var persistentObjects = new Dictionary<string, T>();
            if (_memoryCache.TryGetValue(_typeName, out Dictionary<string, T> modelFromStore))
                persistentObjects = modelFromStore;

            return persistentObjects.Select(pair => pair.Value).ToList();
        }

        public async Task<List<T>> GetAsync(Guid id, params string[] @params)
        {
            var persistentObjects = new Dictionary<string, T>();
            if (_memoryCache.TryGetValue(_typeName, out Dictionary<string, T> modelFromStore))
                persistentObjects = modelFromStore;
            
            var collectionName = new T().GetCollectionName(@params);
            return persistentObjects.ContainsKey($"{collectionName}/{id}")
                ? new List<T> { persistentObjects[$"{collectionName}/{id}"] }
                : new List<T>();
        }
    }
}