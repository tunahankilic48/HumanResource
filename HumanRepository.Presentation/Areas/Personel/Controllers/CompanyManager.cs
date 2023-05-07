using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Presentation.Areas.Personel.Controllers
{
    [Area("personel")]
    [Authorize(Roles = "CompanyManager")]
    public class CompanyManager : Controller
    {
        public async Task<IActionResult> ListEmployee()
        {
            return View();
        }


        public async Task<IActionResult> AddEmployee()
        {
            return View();
        }


        public async Task<IActionResult> UpdateEmployee()
        {
            return View();
        }


        public async Task<IActionResult> DeleteEmployee()
        {
            return View();
        }
        
        public async Task<IActionResult> ListDepartment()
        {
            return View();
        }

        public async Task<IActionResult> CreateDepartment()
        {
            return View();
        }


        public async Task<IActionResult> UpdateDepartment()
        {
            return View();
        }

        public async Task<IActionResult> DeleteDepartment()
        {
            return View();
        }

        public async Task<IActionResult> CreateTitle()
        {
            return View();
        }


        public async Task<IActionResult> UpdateTitle()
        {
            return View();
        }

        public async Task<IActionResult> DeleteTitle()
        {
            return View();
        }

    }
}
