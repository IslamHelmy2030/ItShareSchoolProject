using System;
using System.Threading.Tasks;
using School.Repositories.Repository;

namespace School.Repositories.UnitOfWork
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> Repo { get; }
        Task<int> SaveChanges();
    }
}
