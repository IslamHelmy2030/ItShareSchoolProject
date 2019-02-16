using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.DataLayer.Entities;
using School.Repositories.UnitOfWork;

namespace School.Domain.Abstraction
{
    public class BaseBusiness<T> where T : class 
    {
        public readonly IUnitOfWork<T> UnitOfWork;
        public BaseBusiness(IUnitOfWork<T> unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
