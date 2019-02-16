using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using School.Repositories.Repository;

namespace School.Repositories.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private DbContext _context;
        private IDbContextTransaction _transaction;

        public IRepository<T> Repo { get; }

        public UnitOfWork(DbContext context, IRepository<T> repository)
        {
            _context = context;
            //Repo = new Repository<T>(context);
            Repo = repository;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
