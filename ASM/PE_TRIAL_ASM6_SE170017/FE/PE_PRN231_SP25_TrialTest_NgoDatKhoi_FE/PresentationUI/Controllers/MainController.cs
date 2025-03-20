using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PresentationUI.Models;
using System.Text;
using System.Text.Json;

namespace PresentationUI.Controllers
{
    public class MainController : Controller
    {

        //adding jwt token to the request header
        private async Task AddJwtTokenToRequestHeader(HttpClient httpClient, HttpContext httpContext)
        {
            var tokenString = httpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
            httpClient.DefaultRequestHeaders.Add("Authorization", tokenString);
            await Task.CompletedTask;
        }
        private async Task<T> GetDeserializedResponseFromApi<T>(HttpResponseMessage? response)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return System.Text.Json.JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), options);
        }
        // GET: CosmeticInformations
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                await AddJwtTokenToRequestHeader(httpClient, HttpContext);

                using (var response = await httpClient
                    .GetAsync("https://localhost:7162/api"))
                {
                    var responseObject = await GetDeserializedResponseFromApi<List<CosmeticInformation>>(response);
                    if (response.IsSuccessStatusCode)
                    {
                        return View(responseObject);
                    }
                }
            }
            return View();
        }

        // GET: CosmeticInformations/Create
        public async Task<IActionResult> Create()
        {
            using (var httpClient = new HttpClient())
            {
                await AddJwtTokenToRequestHeader(httpClient, HttpContext);
                //load the view bag quiz
                using (var response = await httpClient.GetAsync("https://localhost:7162/api/viewbag"))
                {
                    var results = await GetDeserializedResponseFromApi<List<string>>(response);
                    ViewBag.CategoryId = results?.Select(x => new SelectListItem
                    {
                        Value = x,
                        Text = x
                    }).ToList();
                }
            }
            return View();
        }
        // GET: CosmeticInformations/Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            using var httpClient = new HttpClient();
            await AddJwtTokenToRequestHeader(httpClient, HttpContext);

            // Load ViewBag with category data
            var categoryResponse = await httpClient.GetAsync("https://localhost:7162/api/viewbag");
            if (categoryResponse.IsSuccessStatusCode)
            {
                var results = await GetDeserializedResponseFromApi<List<string>>(categoryResponse);
                ViewBag.CategoryId = results?.Select(x => new SelectListItem
                {
                    Value = x,
                    Text = x
                }).ToList();
            }

            // Retrieve cosmetic information
            var response = await httpClient.GetAsync($"https://localhost:7162/api/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var res = await GetDeserializedResponseFromApi<CreateUpdateDTO>(response);
            return View(res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUpdateDTO request)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            using (var httpClient = new HttpClient())
            {
                await AddJwtTokenToRequestHeader(httpClient, HttpContext);
                var content = new StringContent(
                 JsonConvert.SerializeObject(request),
                 Encoding.UTF8, "application/json");
                using (var response = await httpClient
                   .PostAsync("https://localhost:7162/api", content))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        TempData["ErrorMessage"] = "Fail create";
                        return View();
                    }
                }
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreateUpdateDTO request)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            using (var httpClient = new HttpClient())
            {
                await AddJwtTokenToRequestHeader(httpClient, HttpContext);
                var content = new StringContent(
                 JsonConvert.SerializeObject(request),
                 Encoding.UTF8, "application/json");
                using (var response = await httpClient
                   .PutAsync("https://localhost:7162/api", content))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        TempData["ErrorMessage"] = "Fail update";
                        return View();
                    }
                }
            }
            return RedirectToAction("Index");
        }


        // GET: CosmeticInformations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            using var httpClient = new HttpClient();
            await AddJwtTokenToRequestHeader(httpClient, HttpContext);

            var response = await httpClient.GetAsync($"https://localhost:7162/api/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var res = await GetDeserializedResponseFromApi<CosmeticInformation>(response);

            return res != null ? View(res) : NotFound();
        }

        // POST: CosmeticInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string CosmeticId)
        {
            if (string.IsNullOrEmpty(CosmeticId))
            {
                return NotFound();
            }

            using var httpClient = new HttpClient();
            await AddJwtTokenToRequestHeader(httpClient, HttpContext);

            var response = await httpClient.DeleteAsync($"https://localhost:7162/api/{CosmeticId}");

            return RedirectToAction(nameof(Index));
        }

        //POST: Search
        [HttpPost]
        public async Task<IActionResult> Search(string item1, string item2, string item3)
        {
            if (string.IsNullOrEmpty(item1) && string.IsNullOrEmpty(item2) && string.IsNullOrEmpty(item3)) return RedirectToAction("Index");
            var httpClient = new HttpClient();
            await AddJwtTokenToRequestHeader(httpClient, HttpContext);
            var req = new SearchRequest();
            req.Item1 = item1??"";
            req.Item2 = item2??"";
            req.Item3 = item3??"";
            var content = new StringContent(
              JsonConvert.SerializeObject(req),
              Encoding.UTF8, "application/json");
            var response = await httpClient
                   .PostAsync("https://localhost:7162/api/search2", content);

            var responseObject = await GetDeserializedResponseFromApi<List<CosmeticInformation>>(response);
            return View("Index", responseObject);
        }
    }
}
