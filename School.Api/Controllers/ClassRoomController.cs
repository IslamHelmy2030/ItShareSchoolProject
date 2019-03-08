using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;

namespace School.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomBusiness _classRoomBusiness;

        public ClassRoomController(IClassRoomBusiness classRoomBusiness)
        {
            _classRoomBusiness = classRoomBusiness;
        }

        [HttpGet(nameof(GetAllClassRooms))]
        public async Task<IActionResult> GetAllClassRooms()
        {
            var result = await _classRoomBusiness.GetAllClassRooms();
            if (result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("GetClassRoom/{id}")]
        public async Task<IActionResult> GetClassRoom(int id)
        {
            var result = await _classRoomBusiness.GetClassRoom(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }

        [HttpPost(nameof(AddClassRoom))]
        public async Task<IActionResult> AddClassRoom(ClassRoomParameter parameter)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _classRoomBusiness.AddClassRoom(parameter);
                if (isAdded)
                {
                    return Ok("Saved Successfully");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut(nameof(UpdateClassRoom))]
        public async Task<IActionResult> UpdateClassRoom(ClassRoomDto parameter)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _classRoomBusiness.UpdateClassRoom(parameter);
                if (isUpdated)
                {
                    return Ok("Updated Successfully");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("DeleteClassRoom/{id}")]
        public async Task<IActionResult> DeleteClassRoom(int id)
        {
            var isDeleted = await _classRoomBusiness.DeleteClassRoom(id);
            if (isDeleted)
            {
                return Ok("Deleted Successfully");
            }

            return BadRequest();
        }
    }
}
