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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherBusiness _TeacherBusiness;

        public TeacherController(ITeacherBusiness TeacherBusiness)
        {
            _TeacherBusiness = TeacherBusiness;
        }

        [HttpGet("GetAllTeachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var result = await _TeacherBusiness.GetAllTeachers();
            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("GetTeacher/{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var result = await _TeacherBusiness.GetTeacher(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }



        [HttpGet("GetAllTeachers/{subjectId}")]
        public async Task<IActionResult> GetAllTeachers(int subjectId)
        {
            var result = await _TeacherBusiness.GetAllTeachers(subjectId);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("GetAllTeachByGender/{genderId}")]
        public async Task<IActionResult> GetAllTeachByGender(int genderId)
        {
            var result = await _TeacherBusiness.GetAllTeachers(genderId);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher(TeacherParameter teacherParameter)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _TeacherBusiness.AddTeacher(teacherParameter);
                if (isAdded)
                {
                    return Ok("Added successfully");
                }
            }
            return BadRequest(ModelState);

        }

        [HttpPut("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher(TeacherDto teacherDto)
        {
            if (ModelState.IsValid)
            {
                var updated = await _TeacherBusiness.UpdateTeacher(teacherDto);
                if (updated)
                {
                    return Ok("Updated successfully");
                }
            }

            return BadRequest(ModelState);
        }


        [HttpDelete("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var deleted = await _TeacherBusiness.DeleteTeacher(id);
            if (deleted)
            {
                return Ok("Deleted successfully");
            }
            return BadRequest();
        }


    }
}