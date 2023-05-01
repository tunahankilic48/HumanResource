using HumanRepository.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HumanRepository.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("index", "personel", new { Area = "personel" });
        }

    }
}