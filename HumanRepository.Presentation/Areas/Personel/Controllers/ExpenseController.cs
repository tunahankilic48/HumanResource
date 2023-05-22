﻿using HumanResource.Application.Models.DTOs.ExpenseDTO;
using HumanResource.Application.Models.VMs.EmailVM;
using HumanResource.Application.Services.EmailSenderService;
using HumanResource.Application.Services.ExpenseService;
using HumanResource.Application.Services.PersonelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.Personel.Controllers
{
	[Authorize]
	[Area("personel")]
	[Authorize(Roles = "CompanyManager, Employee")]
	public class ExpenseController : Controller
	{
		private readonly IExpenseServices _expenseServices;
		private readonly IPersonelService _personelService;
        private readonly IEmailService _emailService;

        public ExpenseController(IExpenseServices expenseServices, IPersonelService personelService, IEmailService emailService)
        {
            _expenseServices = expenseServices;
            _personelService = personelService;
            _emailService = emailService;
        }

        [HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateExpenseDTO model)
		{
			if (ModelState.IsValid)
			{
				var result = await _expenseServices.Create(model, User.Identity.Name);
				if (result)
				{
                    
					TempData["success"] = "Expense request was created successfully.";
					return RedirectToAction("expenses", "personel", new { Area = "personel" });
				}
				else
				{
					TempData["error"] = "Something goes wrong, Expense request could not be created.";
				}
			}
			List<string> errors = new List<string>();
			foreach (var item in ModelState.Values.SelectMany(x => x.Errors))
			{
				errors.Add(item.ErrorMessage);
			}
			TempData["modelError"] = errors.ToArray();
			return RedirectToAction("expenses", "personel", new { Area = "personel" });
		}
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _expenseServices.GetById(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateExpenseDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _expenseServices.Update(model);
                if (result)
                {
                    TempData["success"] = "Expense request was updated successfully.";
                    return RedirectToAction("expenses", "personel", new { Area = "personel" });
                }
                else
                {
                    TempData["error"] = "Something goes wrong, Expense request could not be created.";
                }
            }


            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(IFormCollection collection)
        {
            int id = int.Parse(collection["id"]);
            await _expenseServices.Delete(id);
            TempData["success"] = "Expense was deleted succesfully.";
            return RedirectToAction("expenses", "personel", new { Area = "personel" });
        }

        [HttpGet]
        public async Task<IActionResult> Approve(int id)
        {
            var result = await _expenseServices.Approve(id);
            if (result.Result)
            {
                TempData["success"] = "Personel expense request was approved.";
                var message = new Message(result.UserEmail, "Expense Request", $"Your expense request was approved by your manager.");
                _emailService.SendEmail(message);
                return RedirectToAction("ExpenseRequests", "companymanager", new { Area = "companymanager" });
            }
            TempData["error"] = "There is something wrong. Request could not approved.";
            return RedirectToAction("ExpenseRequests", "companymanager", new { Area = "companymanager" });
        }

        [HttpGet]
        public async Task<IActionResult> Reject(int id)
        {
            var result = await _expenseServices.Reject(id);
            if (result.Result)
            {
                TempData["success"] = "Personel expense request was rejected.";
                var message = new Message(result.UserEmail, "Expense Request", $"Your expense request was rejected by your manager.");
                _emailService.SendEmail(message);
                return RedirectToAction("ExpenseRequests", "companymanager", new { Area = "companymanager" });
            }
            TempData["error"] = "There is something wrong. Request could not rejected.";
            return RedirectToAction("ExpenseRequests", "companymanager", new { Area = "companymanager" });
        }
    }
}
