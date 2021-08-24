using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Track.Persistence.Entities;

namespace Project.Track.Persistence.Storage
{
    internal interface IStorage<T> where T : PersistentObject
    {
        Task<Guid> SaveAsync(T model);
        Task<List<T>> GetAsync();
        Task<List<T>> GetAsync(Guid id, params string[] @params);
    }
}