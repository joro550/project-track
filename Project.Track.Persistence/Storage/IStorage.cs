using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Track.Persistence
{
    internal interface IStorage<T> where T : PersistentObject
    {
        Task SaveAsync(T model);
        Task<List<T>> GetAsync();
        Task<List<T>> GetAsync(Guid id, params string[] @params);
    }
}