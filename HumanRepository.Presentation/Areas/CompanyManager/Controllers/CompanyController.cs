using HumanResource.Application.Models.DTOs.CompanyDTO;
using HumanResource.Application.Services.CompanyManagerService;
using HumanResource.Application.Services.PersonelService;
using HumanResource.Application.Services.SiteAdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "CompanyManager")]
    public class CompanyController : Controller
    {
        private readonly IPersonelService _personelService;
        private readonly ICompanyManagerService _companyManagerService;

        public CompanyController(IPersonelService personelService, ICompanyManagerService companyManagerService)
        {
            _personelService = personelService;
            _companyManagerService = companyManagerService;
        }

        public async Task<IActionResult> Company(Guid id)
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _companyManagerService.GetCompany(id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Company(UpdateCompanyDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _companyManagerService.UpdateCompany(model);
                if (result)
                {
                    TempData["success"] = "Company was updated successfully.";
                    return RedirectToAction("company", "companymanager", new { Area = "companymanager" });
                }
                else
                {
                    TempData["error"] = "Something goes wrong, Company could not be created.";
                }
            }
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(model);
        }
    }
}
