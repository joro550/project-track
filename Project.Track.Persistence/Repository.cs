using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace Project.Track.Persistence
{
    public interface IRepository<T> where T : IPersistentObject
    {
        Task SaveAsync(T model, CancellationToken cancellationToken = default);
        Task<List<T>> GetAsync(Guid id, params string[] parameters);
        Task<List<T>> GetAsync(CancellationToken cancellationToken = default);
    }

    internal class Repository<T> : IRepository<T> where T : PersistentObject, new()
    {
        private readonly IStorage<T> _storage;

        public Repository(IStorage<T> storage)
            => _storage = storage;

        public async Task SaveAsync(T model, CancellationToken cancellationToken = default)
            => await _storage.SaveAsync(model);

        public async Task<List<T>> GetAsync(Guid id, params string[] parameters) 
            => await _storage.GetAsync(id, parameters);

        public async Task<List<T>> GetAsync(CancellationToken cancellationToken = default)
            => await _storage.GetAsync();
    }
}