using ProjectTrack.Domain.Common;

namespace ProjectTrack.Application.Common;

public interface IRepository<T> where T : PersistentObject
{
    Task<Response<T>> InsertAsync(T model);
    Task<Response<T>> GetAsync(string id);
    Task<Response<T>> UpdateAsync(string id, T model);
    Task<Response<T>> DeleteAsync(string id);
}