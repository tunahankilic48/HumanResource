using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanRepository.Presentation.Areas.Personel.Controllers
{
    [Authorize]
    [Area("personel")]
    public class LeaveController : Controller
    {
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete()
        {
            return View();
        }
    }
}
