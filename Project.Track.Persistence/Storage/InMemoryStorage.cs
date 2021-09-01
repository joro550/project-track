using System;
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

        public Task<string> SaveAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAsync(params string[] @params)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAsync(string id, params string[] @params)
        {
            throw new NotImplementedException();
        }
    }
}