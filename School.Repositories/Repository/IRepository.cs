using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Repositories.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(params object[] keys);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<IList<T>> GetAll();
        Task<IList<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<IList<T>> Find(Expression<Func<T, bool>> predicate);
        Task<IList<T>> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<bool> Contains(Expression<Func<T, bool>> predicate);
        T Add(T newEntity);
        void Update(T entity);
        void Update(T entity, object key);
        void Update(T originalEntity, T newEntity);
        void Remove(T entity);
        void Remove(Expression<Func<T, bool>> predicate);
        void RemoveRange(IEnumerable<T> entities);
        object GetKeyValue(T t);
        string GetKeyField(Type type);
    }
}
