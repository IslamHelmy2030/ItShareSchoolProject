using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;


namespace School.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectBusiness _subjectBusiness;

        public SubjectController(ISubjectBusiness subjectBusiness)
        {
            _subjectBusiness = subjectBusiness;

        }

        [HttpGet("GetAllSubjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var result = await _subjectBusiness.GetAllSubjects();
            if (result.Any())
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("GetSubject/{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            var result = await _subjectBusiness.GetSubject(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }

        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject(SubjectParameter parameter)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _subjectBusiness.AddSubject(parameter);
                if (isAdded)
                {
                    return Ok("Added Successfully");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject(SubjectDto subjectDto)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _subjectBusiness.UpdateSubject(subjectDto);
                if (isUpdated)
                {
                    return Ok("Updated Successfully");
                }
            }
            return BadRequest(ModelState);

        }
        [HttpDelete("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var isDeleted = await _subjectBusiness.DeleteSubject(id);
            if (isDeleted)
            {
                return Ok("Deleted Successfully");
            }

            return BadRequest();
        }



    }
}