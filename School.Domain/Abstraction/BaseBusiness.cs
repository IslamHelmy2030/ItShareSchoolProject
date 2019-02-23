using AutoMapper;
using School.Repositories.UnitOfWork;

namespace School.Domain.Abstraction
{
    public class BaseBusiness<T> where T : class
    {
        public readonly IUnitOfWork<T> UnitOfWork;
        public readonly IMapper Mapper;


        public BaseBusiness(IUnitOfWork<T> unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}
