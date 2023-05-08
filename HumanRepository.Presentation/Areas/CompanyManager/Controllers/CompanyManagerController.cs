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

        public async Task<IActionResult> ListEmployee()
        {

            return View();
        }


        public async Task<IActionResult> AddEmployee()
        {
            return View();
        }


        public async Task<IActionResult> UpdateEmployee()
        {
            return View();
        }


        public async Task<IActionResult> DeleteEmployee()
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
