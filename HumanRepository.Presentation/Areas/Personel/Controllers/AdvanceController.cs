using HumanResource.Application.Models.DTOs.AdvanceDTOs;
using HumanResource.Application.Models.VMs.AdvanceVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HumanResource.Presentation.Areas.Personel.Controllers
{
    public class AdvanceController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<AdvanceVM> advanceList = new List<AdvanceVM>();
            using (HttpClient httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:")) //URL düzenlenecek.
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advanceList = JsonConvert.DeserializeObject<List<AdvanceVM>>(apiResponse);
                }
            }
            return View(advanceList);
        }

        public async Task<IActionResult> Create()
        {
            CreateAdvanceDTO createAdvance = new CreateAdvanceDTO();
            using (HttpClient httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:")) // URL Düzenlenecek
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    createAdvance = JsonConvert.DeserializeObject<CreateAdvanceDTO>(apiResponse);
                }
            }
            ViewBag.User = new SelectList(createAdvance.Users, "Id", "FirstName","Department");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAdvanceDTO model)
        {
            if(ModelState.IsValid)
            {
                CreateAdvanceDTO createAdvances = new CreateAdvanceDTO();
                using (HttpClient httpclient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8, "application/json");

                    using (var response = await httpclient.PostAsync("https://localhost", content))//URL düzenlenecek.
                    {
                        if (response.IsSuccessStatusCode)
                            return RedirectToAction("Index");
                    }
                }
            }
            CreateAdvanceDTO createAdvance = new CreateAdvanceDTO();
            using (HttpClient httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:"))//URL düzenlenecek.
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    createAdvance = JsonConvert.DeserializeObject<CreateAdvanceDTO>(apiResponse);
                }
            }
            ViewBag.User = new SelectList(createAdvance.Users, "Id", "FirstName");

            return View(model);
        }

        public async Task<IActionResult> Update(int id)
        {
            UpdateAdvanceDTO advance = new UpdateAdvanceDTO();
            using (HttpClient httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:7157" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advance = JsonConvert.DeserializeObject<UpdateAdvanceDTO>(apiResponse);
                }
            }
            CreateAdvanceDTO createAdvance = new CreateAdvanceDTO();
            using (HttpClient httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:7157/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    createAdvance = JsonConvert.DeserializeObject<CreateAdvanceDTO>(apiResponse);
                }
            }
            ViewBag.User = new SelectList(createAdvance.Users, "Id", "FirstName","Department");

            return View(advance);


        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAdvanceDTO model)
        {
            if (ModelState.IsValid)
            {
                UpdateAdvanceDTO updateAdvances = new UpdateAdvanceDTO();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync("https://localhost", content))//URL Düzenlenecek
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }

            CreateAdvanceDTO createAdvances = new CreateAdvanceDTO();
            using (HttpClient httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:7157/api/Post/CreatePostElements"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    createAdvances = JsonConvert.DeserializeObject<CreateAdvanceDTO>(apiResponse);
                }
            }
            ViewBag.User = new SelectList(createAdvances.Users, "Id", "FirstName");

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            UpdateAdvanceDTO advance = new UpdateAdvanceDTO();
            using (HttpClient httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost" + id))//URL düzenlenecek
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advance = JsonConvert.DeserializeObject<UpdateAdvanceDTO>(apiResponse);
                }
            }
            return View(advance);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost" + id)) { }//URL düzenlenecek
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(int id)
        {
            AdvanceVM advances = new AdvanceVM();
            using (HttpClient httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync("https://localhost:" + id))//URL düzenlenecek
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    advances = JsonConvert.DeserializeObject<AdvanceVM>(apiResponse);
                }
            }
            return View(advances);
        }
    }
}
