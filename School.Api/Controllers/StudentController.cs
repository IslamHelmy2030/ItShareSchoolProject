using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {

        private readonly IStudentBusiness _StudentBusiness;

        public StudentController(IStudentBusiness StudentBusiness)
        {
            _StudentBusiness = StudentBusiness;
        }

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _StudentBusiness.GetAllStudents();
            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();

        }

        [HttpGet("GetStudent/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {

            var result = await _StudentBusiness.GetStudent(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("GetAllStudents/{classRoomId}")]
        public async Task<IActionResult> GetAllStudents(int classRoomId)
        {
            var result = await _StudentBusiness.GetAllStudents(classRoomId);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("GetAllStudentsByGender/{genderId}")]
        public async Task<IActionResult> GetAllStudentsByGender(int genderId)
        {
            var result = await _StudentBusiness.GetAllStudentsByGender(genderId);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }


        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentParameter studentParameter)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _StudentBusiness.AddStudent(studentParameter);
                if (isAdded)
                {
                    return Ok("Added successfully");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                var updated = await _StudentBusiness.UpdateStudent(studentDto);
                if (updated)
                {
                    return Ok("Updated successfully");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _StudentBusiness.DeleteStudent(id);
            if (deleted)
            {
                return Ok("Deleted successfully");
            }
            return BadRequest();


        }

    }
}