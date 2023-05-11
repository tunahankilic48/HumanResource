using HumanResource.Application.Services.PersonelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "CompanyManager")]
    public class CompanyController : Controller
    {
        private readonly IPersonelService _personelService;

        public CompanyController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        public async Task<IActionResult> Company()
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View();
        }
    }
}
