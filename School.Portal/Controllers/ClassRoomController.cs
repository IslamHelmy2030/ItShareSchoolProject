using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;
using School.Domain.Interfaces.DtoInterfaces;

namespace School.Portal.Controllers
{
    public class ClassRoomController : Controller
    {
        private readonly IClassRoomBusiness _classRoomBusiness;
        private readonly ILevelBusiness _levelBusiness;
        public ClassRoomController(IClassRoomBusiness classRoomBusiness,ILevelBusiness levelBusiness)
        {
            _classRoomBusiness = classRoomBusiness;
            _levelBusiness = levelBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var classRooms = await _classRoomBusiness.GetAllClassRooms();
            return View(classRooms);
        }

        public async Task<IActionResult> Create()
        {
            await GetLevelsDropDownList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClassRoomParameter parameter)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _classRoomBusiness.AddClassRoom(parameter);
                if (isAdded) return RedirectToAction("Index");
            }

            return View(parameter);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var classRoom = await _classRoomBusiness.GetClassRoom(id);
            await GetLevelsDropDownList(classRoom.LevelId);
            return View(classRoom);
        }

        private async Task GetLevelsDropDownList(int levelId = -1)
        {
            var levels = await _levelBusiness.GetAllLevels();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var levelDto in levels)
            {
                var item = new SelectListItem
                {
                    Text = levelDto.LevelName,
                    Value = levelDto.LevelId.ToString(),
                    Selected = levelDto.LevelId == levelId
                };
                listItems.Add(item);
            }

            ViewBag.Levels = listItems;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClassRoomDto parameter)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _classRoomBusiness.UpdateClassRoom(parameter);
                if (isUpdated) return RedirectToAction("Index");
            }

            return View(parameter);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _classRoomBusiness.DeleteClassRoom(id);
            return RedirectToAction("Index");
        }
    }
}