using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Track.Persistence.Entities;

namespace Project.Track.Persistence.Storage
{
    internal interface IStorage<T> where T : PersistentObject
    {
        Task<string> SaveAsync(T model);
        Task<List<T>> GetAsync(params string[] @params);
        Task<List<T>> GetAsync(string id, params string[] @params);
    }
}