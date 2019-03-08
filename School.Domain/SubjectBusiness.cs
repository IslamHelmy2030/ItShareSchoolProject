using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using School.DataLayer.Entities;
using School.Domain.Abstraction;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;
using School.Domain.Interfaces.DtoInterfaces;
using School.Repositories.UnitOfWork;

namespace School.Domain
{
    public class SubjectBusiness : BaseBusiness<Subject>, ISubjectBusiness
    {

        public SubjectBusiness(IUnitOfWork<Subject> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public async Task<bool> AddSubject(SubjectParameter subjectName)
        {
            var subject = Mapper.Map<SubjectParameter, Subject>(subjectName);
            UnitOfWork.Repo.Add(subject);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> DeleteSubject(int id)
        {
            UnitOfWork.Repo.Remove(x => x.Id == id);
            return await UnitOfWork.SaveChanges() > 0;
        }

        public async Task<IEnumerable<ISubjectDto>> GetAllSubjects()
        {
            var subjects = await UnitOfWork.Repo.GetAll();
            var subjectDtos = Mapper.Map<IEnumerable<Subject>, IEnumerable<ISubjectDto>>(subjects);
            return subjectDtos;

        }

        public async Task<ISubjectDto> GetSubject(int id)
        {
            var subject = await UnitOfWork.Repo.FirstOrDefault(x => x.Id == id);
            var subjectDto = Mapper.Map<Subject, ISubjectDto>(subject);
            return subjectDto;
        }

        public async Task<bool> UpdateSubject(SubjectDto subjectParameter)
        {
            var subject = Mapper.Map<ISubjectDto, Subject>(subjectParameter);
            UnitOfWork.Repo.Update(subject);
            return await UnitOfWork.SaveChanges() > 0;
        }
    }
}
