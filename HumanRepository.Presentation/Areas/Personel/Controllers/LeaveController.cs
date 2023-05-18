using HumanResource.Application.Models.DTOs.LeaveDTO;
using HumanResource.Application.Models.VMs.EmailVM;
using HumanResource.Application.Services.EmailSenderService;
using HumanResource.Application.Services.LeaveServices;
using HumanResource.Application.Services.PersonelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.Personel.Controllers
{
    [Area("personel")]
    [Authorize(Roles = "CompanyManager, Employee")]
    public class LeaveController : Controller
    {
        private readonly ILeaveService _leaveService;
        private readonly IPersonelService _personelService;
        private readonly IEmailService _emailService;

        public LeaveController(ILeaveService leaveService, IPersonelService personelService, IEmailService emailService)
        {
            _leaveService = leaveService;
            _personelService = personelService;
            _emailService = emailService;
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

        [HttpGet]
        public async Task<IActionResult> Approve(int id)
        {
            var result = await _leaveService.Approve(id);
            if (result.Result)
            {
                TempData["success"] = "Personel leave request was approved.";
                var message = new Message(result.UserEmail, "Leave Request", $"Your leave request was approved by your manager.");
                _emailService.SendEmail(message);
                return RedirectToAction("leaveRequests", "companymanager", new { Area = "companymanager" });
            }
            TempData["error"] = "There is something wrong. Request could not approved.";
            return RedirectToAction("leaveRequests", "companymanager", new { Area = "companymanager" });
        }

        [HttpGet]
        public async Task<IActionResult> Reject(int id)
        {
            var result = await _leaveService.Reject(id);
            if (result.Result)
            {
                TempData["success"] = "Personel leave request was rejected.";
                var message = new Message(result.UserEmail, "Leave Request", $"Your leave request was rejected by your manager.");
                _emailService.SendEmail(message);
                return RedirectToAction("leaveRequests", "companymanager", new { Area = "companymanager" });
            }
            TempData["error"] = "There is something wrong. Request could not rejected.";
            return RedirectToAction("leaveRequests", "companymanager", new { Area = "companymanager" });
        }
    }
}
