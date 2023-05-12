using HumanResource.Application.Services.PersonelService;
using HumanResource.Application.Services.SiteAdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.SiteAdmin
{
    [Area("SiteAdmin")]
    [Authorize(Roles = "SiteAdmin")]
    public class SiteAdminController : Controller
    {
        private readonly ISiteAdminService _siteAdminService;
        private readonly IPersonelService _personelService;

        public SiteAdminController(ISiteAdminService siteAdminService, IPersonelService personelService)
        {
            _siteAdminService = siteAdminService;
            _personelService = personelService;
        }
        public async Task <IActionResult> Index()
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _siteAdminService.GetCompanyManagerRequests());
        }
    }
}
