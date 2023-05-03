using HumanResource.Application.Models.DTOs.LeaveDTO;
using HumanResource.Application.Services.LeaveServices;
using HumanResource.Application.Services.PersonelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.Personel.Controllers
{
    [Authorize]
    [Area("personel")]
    public class LeaveController : Controller
    {
        private readonly ILeaveService _leaveService;
        private readonly IPersonelService _personelService;

        public LeaveController(ILeaveService leaveService, IPersonelService personelService)
        {
            _leaveService = leaveService;
            _personelService = personelService;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLeaveDTO model)
        {
            if (ModelState.IsValid)
            {
               var result = await _leaveService.Create(model, User.Identity.Name);
                if(result)
                {
                    TempData["success"] = "Leave request was created successfully.";
                    return RedirectToAction("leaves", "personel", new { Area = "personel" });
                }
                else
                {
                    TempData["error"] = "Something goes wrong, Leave request could not be created.";
                }
            }
            List<string> errors = new List<string>();
            foreach (var item in ModelState.Values.SelectMany(x=>x.Errors))
            {
                errors.Add(item.ErrorMessage);
            }
            TempData["modelError"] = errors.ToArray();
            return RedirectToAction("leaves", "personel", new { Area = "personel" });
        }


        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _leaveService.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateLeaveDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _leaveService.Update(model);
                if (result)
                {
                    TempData["success"] = "Leave request was created successfully.";
                    return RedirectToAction("leaves", "personel", new { Area = "personel" });
                }
                else
                {
                    TempData["error"] = "Something goes wrong, Leave request could not be created.";
                }
            }


            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(IFormCollection collection)
        {
            int id = int.Parse(collection["id"]);
            await _leaveService.Delete(id);
            TempData["success"] = "Leave was deleted succesfully.";
            return RedirectToAction("leaves", "personel", new { Area = "personel" });
        }
    }
}
