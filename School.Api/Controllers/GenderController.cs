using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;

namespace School.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderBusiness _genderBusiness;

        public GenderController(IGenderBusiness genderBusiness)
        {
            _genderBusiness = genderBusiness;
        }

        [HttpGet("GetAllGenders")]
        public async Task<IActionResult> GetGenders()
        {
            var result = await _genderBusiness.GetAllGenders();
            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("GetGender/{id}")]
        public async Task<IActionResult> GetGender(int id)
        {
            var result = await _genderBusiness.GetGender(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost("AddNewGender")]
        public async Task<IActionResult> AddGender([FromBody]GenderParameter gender)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _genderBusiness.AddGender(gender);
                if (isAdded)
                {
                    return Ok("Saved Successfully");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPut("UpdateOldGender")]
        public async Task<IActionResult> UpdateGender([FromBody] GenderDto gender)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _genderBusiness.UpdateGender(gender);
                if (isUpdated) return Ok("Updated Successfully");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteGender/{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            var isDeleted = await _genderBusiness.DeleteGender(id);
            if (isDeleted) return Ok("Deleted Successfully");
            return BadRequest();
        }
    }
}