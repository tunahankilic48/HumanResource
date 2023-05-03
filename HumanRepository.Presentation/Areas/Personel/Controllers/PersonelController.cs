using HumanResource.Application.Services.AdvanceService;
using HumanResource.Application.Services.LeaveServices;
using HumanResource.Application.Services.PersonelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.Personel.Controllers
{
    [Authorize]
    [Area("personel")]
    public class PersonelController : Controller
    {
        private readonly IPersonelService _personelService;
        private readonly IAdvanceService _advanceService;
        private readonly ILeaveService _leaveservice;

        public PersonelController(IPersonelService personelService, IAdvanceService advanceService, ILeaveService leaveservice)
        {
            _personelService = personelService;
            _advanceService = advanceService;
            _leaveservice = leaveservice;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.AdvanceRequests = await _personelService.GetPersonelAdvanceRequests(User.Identity.Name);
            ViewBag.LeaveRequests = await _personelService.GetPersonelLeaveRequests(User.Identity.Name);
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View();
        }

        public async Task<IActionResult> Advances()
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _advanceService.GetAdvancesForPersonel(await _personelService.GetPersonelId(User.Identity.Name)));
        }

        public async Task<IActionResult> Leaves()
        {


            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _leaveservice.GetLeavesForPersonel(await _personelService.GetPersonelId(User.Identity.Name)));
        }
    }
}
