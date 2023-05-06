using HumanResource.Application.Models.DTOs.AccountDTO;
using HumanResource.Application.Services.AccountServices;
using HumanResource.Application.Services.PersonelService;
using HumanResource.Domain.Entities;
using HumanResource.Domain.Repositries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace HumanResource.Presentation.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;
        private readonly IEmailSender _emailSender;
		private readonly UserManager<AppUser> _userManager;
		public AccountController(IAccountServices accountServices, IEmailSender emailSender)
		{
			_accountServices = accountServices;
			_emailSender = emailSender;
		}
		[AllowAnonymous] 
        public IActionResult Register()
        {
            if(User.Identity.IsAuthenticated) 
                return RedirectToAction("login", "account");

			return View();
        }
        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if(ModelState.IsValid)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(model.User);
				var url = Url.Action("ConfirmedEmail", "Account", new
				{  //bu kısım url oluşturuyor.
					userId = model.User.Id,
					token = code
				});
				await _emailSender.SendEmailAsync(model.Email, "Lütfen hesabınız onaylayınız", $"Lütfen email hesabınızı onaylanmak için linke <a href='https://localhost:44317{url}'>tıklayınız</a> ");
				var result = await _accountServices.Register(model);

                if(result.Succeeded)
                    return RedirectToAction("login", "account");

				foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,item.Description);
                    TempData["Error"] = "Yanlış birşeyler var";
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

                ModelState.AddModelError("", "Geçersiz giriş");
            }
			ViewData["ReturnUrl"] = returnUrl;
			return View(model);
        }
        
        public async Task<IActionResult> LogOut()
        {
            await _accountServices.LogOut();
            return RedirectToAction("login");
        }
        public async Task<IActionResult> Edit(string userName)
        {
            return View(await _accountServices.GetByUserName(userName));
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateProfileDTO model)
        {
            if (ModelState.IsValid)
            {
                await _accountServices.UpdateUser(model);
                return RedirectToAction("detail");//ToDo : kendi sayfasına = personel control altındaki index sayfasına gidecek (Area)
            }
            return View(model);
        }

        public async Task<IActionResult> Details(string UserName)//ToDo : personelde mi yoksa account ta mı olacak bu action
        {
            return View(await _accountServices.GetByUserName(UserName));
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
    }
}
