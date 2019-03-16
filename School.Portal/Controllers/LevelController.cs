using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Portal.Controllers
{
    public class LevelController : Controller
    {
        private readonly ILevelBusiness _levelBusiness;

        public LevelController(ILevelBusiness levelBusiness)
        {
            _levelBusiness = levelBusiness;
        }

        public async Task<IActionResult> GetAllLevels()
        {
            var levels = await _levelBusiness.GetAllLevels();
            return View("Index", levels);
        }

        public async Task<IActionResult> AddOrUpdate(int? id)
        {
            ILevelDto level = new LevelDto();
            if (id != null)
            {
                level = await _levelBusiness.GetLevel(Convert.ToInt32(id));
            }
            return View(level);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdate(LevelDto levelDto)
        {
            if (levelDto.LevelId > 0)
                await _levelBusiness.UpdateLevel(levelDto);
            else
            {
                var levelParameter = new LevelParameter {LevelName = levelDto.LevelName};
                await _levelBusiness.AddLevel(levelParameter);
            }
            return RedirectToAction("GetAllLevels");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await _levelBusiness.DeleteLevel(id);
            return RedirectToAction("GetAllLevels");
        }
    }
}
