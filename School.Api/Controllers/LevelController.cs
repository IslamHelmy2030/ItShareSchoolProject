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
    public class LevelController : ControllerBase
    {

        private readonly ILevelBusiness _levelBusiness;

        public LevelController(ILevelBusiness levelBusiness)
        {
            _levelBusiness = levelBusiness;
        }
        [HttpGet("GetAllLevels")]
        public async Task<IActionResult> GetAllLevels()
        {
            var result = await _levelBusiness.GetAllLevels();
            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();

        }
        [HttpGet("GetLevel/{id}")]
        public async Task<IActionResult> GetLevel(int id)
        {
            var result = await _levelBusiness.GetLevel(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }

        [HttpPost("AddLevel")]
        public async Task<IActionResult> AddLevel(LevelParameter levelparameter)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _levelBusiness.AddLevel(levelparameter);
                if (isAdded)
                {
                    return Ok("Added successfully");
                }
            }
            return BadRequest(ModelState);

        }

        [HttpPut("updateLevel")]
        public async Task<IActionResult> UpdateLevel(LevelDto leveldto)
        {
            if (ModelState.IsValid)
            {
                var updated = await _levelBusiness.UpdateLevel(leveldto);
                if (updated)
                {
                    return Ok("updated successfully");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteLevel")]
        public async Task<IActionResult> DeleteLevel(int id)
        {
            var deleted = await _levelBusiness.DeleteLevel(id);
            if (deleted)
            {
                return Ok("deleted successfully");
            }
            return BadRequest();
        }
    }
}