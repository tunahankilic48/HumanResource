using HumanResource.Application.Models.DTOs.AdvanceDTOs;
using HumanResource.Application.Services.AdvanceService;
using HumanResource.Application.Services.PersonelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.Personel.Controllers
{
    [Authorize]
    [Area("personel")]
    [Authorize(Roles = "CompanyManager, Employee")]
    public class AdvanceController : Controller
    {
        private readonly IAdvanceService _advanceService;
        private readonly IPersonelService _personelService;

        public AdvanceController(IPersonelService personelService, IAdvanceService advanceService)
        {
            _personelService = personelService;
            _advanceService = advanceService;
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAdvanceDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _advanceService.Create(model, User.Identity.Name);
                if (result)
                {
                    TempData["success"] = "advance request was created successfully.";
                    return RedirectToAction("advances", "personel", new { Area = "personel" });
                }
                else
                {
                    TempData["error"] = "Something goes wrong, Advance request could not be created.";
                }
            }
            List<string> errors = new List<string>();
            foreach (var item in ModelState.Values.SelectMany(x => x.Errors))
            {
                errors.Add(item.ErrorMessage);
            }
            TempData["modelError"] = errors.ToArray();
            return RedirectToAction("advances", "personel", new { Area = "personel" });
        }


        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _advanceService.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateAdvanceDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _advanceService.Update(model);
                if (result)
                {
                    TempData["success"] = "advance request was created successfully.";
                    return RedirectToAction("advances", "personel", new { Area = "personel" });
                }
                else
                {
                    TempData["error"] = "Something goes wrong, Advance request could not be created.";
                }
            }


            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(IFormCollection collection)
        {
            int id = int.Parse(collection["id"]);
            await _advanceService.Delete(id);
            TempData["success"] = "advance was deleted succesfully.";
            return RedirectToAction("advances", "personel", new { Area = "personel" });
        }
    }
}
