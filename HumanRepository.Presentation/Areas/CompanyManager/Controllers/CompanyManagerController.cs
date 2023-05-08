using HumanResource.Application.Models.DTOs.CompanyManagerDTO;
using HumanResource.Application.Services.CompanyManagerService;
using HumanResource.Application.Services.PersonelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "CompanyManager")]
    public class CompanyManagerController : Controller
    {
        private readonly ICompanyManagerService _companyManagerService;
        private readonly IPersonelService _personelService;

        public CompanyManagerController(ICompanyManagerService companyManagerService, IPersonelService personelService)
        {
            _companyManagerService = companyManagerService;
            _personelService = personelService;
        }

        public async Task<IActionResult> Employees()
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _companyManagerService.GetEmployees());
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeDTO model)
        {
            return View();
        }


        public async Task<IActionResult> Update(Guid id)
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            return View();
        }

        public async Task<IActionResult> Departments()
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _companyManagerService.GetDepartments());
        }     
        
        
        public async Task<IActionResult> Titles()
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _companyManagerService.GetTitles());
        }



    }
}
