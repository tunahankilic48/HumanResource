using HumanResource.Application.Models.DTOs.AccountDTO;
using HumanResource.Application.Models.VMs.EmailVM;
using HumanResource.Application.Services.AccountServices;
using HumanResource.Application.Services.AddressService;
using HumanResource.Application.Services.EmailSenderService;
using HumanResource.Application.Services.PersonelService;
using HumanResource.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace HumanResource.Presentation.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private readonly IAccountServices _accountServices;
		private readonly IPersonelService _personelService;
		private readonly IAddressService _addressService;
		private readonly IEmailService _emailService;
		private readonly UserManager<AppUser> _userManager;
		public AccountController(IAccountServices accountServices, IPersonelService personelService, IAddressService addressService, IEmailService emailService)
		{
			_accountServices = accountServices;
			_personelService = personelService;
			_addressService = addressService;
			_emailService = emailService;
		}

		[AllowAnonymous]
		public IActionResult Register()
		{
			if (User.Identity.IsAuthenticated)
				return RedirectToAction("login", "account");

			return View();
		}
		[AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterDTO model)
		{
			if (ModelState.IsValid)
			{

				var result = await _accountServices.Register(model);

				if (result.Result.Succeeded)
				{
					
					var conformationLink = Url.Action("ConfirmEmail", "Account", new { token = result.Token, email = result.Email }, Request.Scheme);

					var message = new Message(new string[] { result.Email! }, "Conformation Email Link", conformationLink!);
					_emailService.SendEmail(message);

					TempData["Conformation"] = "Please check your mailbox and verify your email!";

					return RedirectToAction("login", "account");
				}

				foreach (var item in result.Result.Errors)
				{
					ModelState.AddModelError(string.Empty, item.Description);
					TempData["Error"] = "there is something wrong";
				}
			}
			return View(model);
		}

		[AllowAnonymous]
		public IActionResult Login(string returnUrl = "/")
		{
			if (User.Identity.IsAuthenticated)
				return RedirectToAction("index", "personel", new { Area = "personel" });

			ViewData["ReturnUrl"] = returnUrl;

			return View();
		}
		[AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginDTO model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				var result = await _accountServices.Login(model);

				if (result.Succeeded)
					return RedirectToLocal(returnUrl);

				ModelState.AddModelError("", "Invalid login");
			}
			ViewData["ReturnUrl"] = returnUrl;
			return View(model);
		}

		public async Task<IActionResult> LogOut()
		{
			await _accountServices.LogOut();
			return RedirectToAction("login");
		}
		public async Task<IActionResult> Profile()
		{
			ViewBag.Cities = new SelectList(await _addressService.GetCities(), "Id", "Name");
			ViewBag.Districts = new SelectList(await _addressService.GetDistricts(), "Id", "Name");
			ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
			return View(await _accountServices.GetByUserName(User.Identity.Name));
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Profile(UpdateProfileDTO model)
		{
			if (ModelState.IsValid)
			{
				await _accountServices.UpdateUser(model);
				return RedirectToAction("profile");
			}
			ViewBag.Cities = new SelectList(await _addressService.GetCities(), "Id", "Name");
			ViewBag.Districts = new SelectList(await _addressService.GetDistricts(), "Id", "Name");
			ViewBag.Personel = await _personelService.GetPersonel(User.Identity.Name);
			return View(model);
		}
		[HttpGet]
		public async Task<JsonResult> setDropDrownList(int id)
		{
			var districts = await _addressService.GetDistricts(id);
			return Json(districts);
		}



		private IActionResult RedirectToLocal(string returnUrl = "/")
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction("index", "");
			}
		}

		[AllowAnonymous]
		public async Task<IActionResult> ConfirmEmail(string token, string email)
		{
			var result = await _accountServices.ConfirmEmail(token, email); // ToDo: resulta göre sayfa yapılacak

			if (result.Succeeded)
			{
				TempData["SuccessConformation"] = "Your account was confirmed successfully.";
				return RedirectToAction("Login");

			}
            TempData["ErrorConformation"] = "Your account could not confirmed. Please register again.";
            return RedirectToAction("register");

		}
	}
}
