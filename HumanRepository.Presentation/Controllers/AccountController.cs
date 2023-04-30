using HumanResource.Application.Models.DTOs.AccountDTO;
using HumanResource.Application.Services.AccountServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanRepository.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        [AllowAnonymous] // --> Kimliği doğrulanmamış kullanıcıların tek tek eylemlere erişmesine izin vermek için özniteliğini de kullanabilirsiniz
        public IActionResult Register()
        {
            if(User.Identity.IsAuthenticated/*Kimlik doğrulanıp doğrulanmadığını kontrol eder*/) return RedirectToAction("Index");

           return View();
        }
        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountServices.Register(model);

                if(result.Succeeded) return RedirectToAction("Index");

                foreach(var item in result.Errors)
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
            if (User.Identity.IsAuthenticated /*Kimlik doğrulanıp doğrulanmadığını kontrol eder*/) return RedirectToAction("Index");

            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }
        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Login(LoginDTO login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountServices.Login(login);

                if (result.Succeeded) return RedirectToAction(returnUrl);

                ModelState.AddModelError("", "Geçersiz giriş");
            }
            return View();
        }
        
        public async Task<IActionResult> LogOut()
        {
            await _accountServices.LogOut();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(string userName)
        {
            return View(await _accountServices.GetByUserName(userName));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProfileDTO model)
        {
            if (ModelState.IsValid)
            {
                await _accountServices.UpdateUser(model);
                return RedirectToAction("detail");
            }
            return RedirectToAction("edit");
        }

        public async Task<IActionResult> Details(string UserName)
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

        //ToDo : her action metodun cshtml(Razzor View'e oluşturulacak)
    }
}
