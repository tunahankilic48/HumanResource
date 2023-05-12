using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.SiteAdmin
{
    [Area("SiteAdmin")]
    [Authorize(Roles = "SiteAdmin")]
    public class SiteAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
