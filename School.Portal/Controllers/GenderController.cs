using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Dto;
using School.Domain.Dto.Parameters;
using School.Domain.Interfaces.BusinessInterfaces;

namespace School.Portal.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderBusiness _genderBusiness;

        public GenderController(IGenderBusiness genderBusiness)
        {
            _genderBusiness = genderBusiness;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _genderBusiness.GetAllGenders();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GenderParameter parameter)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _genderBusiness.AddGender(parameter);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(parameter);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var gender = await _genderBusiness.GetGender(id);
            return View(gender);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GenderDto parameter)
        {
            if (ModelState.IsValid)
            {
                var isUpdated = await _genderBusiness.UpdateGender(parameter);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(parameter);
        }

        public async Task<IActionResult> Details(int id)
        {
            var gender = await _genderBusiness.GetGender(id);
            return View(gender);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var gender = await _genderBusiness.GetGender(id);
            return View(gender);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GenderDto genderDto)
        {
            await _genderBusiness.DeleteGender(genderDto.GenderId);
            return RedirectToAction("Index");
        }
    }
}