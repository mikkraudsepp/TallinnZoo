using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.DAL.Base.Repositories
{
    [Obsolete("IBaseRepository<TEntity> does not support async, please use IBaseRepositoryAsync<TEntity> instead!")]
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : class, IBaseEntity<Guid>, new()
    {
    }

    public interface IBaseRepositoryAsync<TEntity> : IBaseRepositoryAsync<TEntity, Guid>
        where TEntity : class, IBaseEntity<Guid>, new()
    {
    }

    [Obsolete("IBaseRepository<TEntity, TKey> does not support async, please use IBaseRepositoryAsync<TEntity, TKey> instead!")]
    public interface IBaseRepository<TEntity, TKey> : IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TKey : struct, IComparable
    {
        IList<TEntity> All();
        TEntity Find(params object[] id);
        void Add(TEntity entity);
    }

    public interface IBaseRepositoryAsync<TEntity, TKey> : IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TKey : struct, IComparable
    {
        Task<IList<TEntity>> AllAsync();
        Task<TEntity> FindAsync(params object[] id);
        Task AddAsync(TEntity entity);
    }

    public interface IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>, new()
        where TKey : struct, IComparable
    {
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(params object[] id);
    }

}