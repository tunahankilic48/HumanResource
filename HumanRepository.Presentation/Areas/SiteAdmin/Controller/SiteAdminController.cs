using HumanResource.Application.Models.VMs.EmailVM;
using HumanResource.Application.Services.AddressService;
using HumanResource.Application.Services.CompanyManagerService;
using HumanResource.Application.Services.CompanyService;
using HumanResource.Application.Services.EmailSenderService;
using HumanResource.Application.Services.PersonelService;
using HumanResource.Application.Services.SiteAdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HumanResource.Presentation.Areas.SiteAdmin
{
    [Area("SiteAdmin")]
    [Authorize(Roles = "SiteAdmin")]
    public class SiteAdminController : Controller
    {
        private readonly ISiteAdminService _siteAdminService;
        private readonly IPersonelService _personelService;
        private readonly ICompanyManagerService _companyManagerService;
        private readonly ICompanyService _companyService;
        private readonly IEmailService _emailService;
        private readonly IAddressService _addressService;

		public SiteAdminController(ISiteAdminService siteAdminService, IPersonelService personelService, ICompanyManagerService companyManagerService, IEmailService emailService, ICompanyService companyService, IAddressService addressService)
		{
			_siteAdminService = siteAdminService;
			_personelService = personelService;
			_companyManagerService = companyManagerService;
			_emailService = emailService;
			_companyService = companyService;
			_addressService = addressService;
		}
		public async Task<IActionResult> Index()
        {
            ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
            return View(await _siteAdminService.GetCompanyManagerRequests());
        }
        public async Task<IActionResult> Approve(Guid companyManagerId)
        {

            
            var companyManager = await _siteAdminService.GetCompanyManager(companyManagerId);

            var conformationLink = Url.Action("ConfirmEmail", "Account", new { token = companyManager.Token, email = companyManager.Email, Area = "" }, Request.Scheme);

            var message = new Message(companyManager.Email, "Conformation Email Link", $"Welcome to our human resources platform. Please click the link to activate your account. {conformationLink!}   You can use your email below to login to the platform. ");
            _emailService.SendEmail(message);

            return RedirectToAction("index", "siteadmin", new { Area = "siteadmin" });



        }
        public async Task<IActionResult> Details (int id)
        {
            return View(await _siteAdminService.GetCompanyId(id));
		}
    }
}
