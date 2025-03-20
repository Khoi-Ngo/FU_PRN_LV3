using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PresentationUI.Models;
using System.Text.Json;

namespace Pre_maritalCounSeling.MVC.Controllers
{
    public class AuthController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO request)
        {

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync("https://localhost:7162/api/login", request))
                    {
                        var tokenString = (await GetDeserializedResponseFromApi(response))["token"];
                        Response.Cookies.Append("TokenString", tokenString);
                        return RedirectToAction("Index", "Main");

                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                ModelState.AddModelError("", "You are not allowed to access this function!");
                return View();
            }
        }

        private async Task<Dictionary<string, string>?> GetDeserializedResponseFromApi(HttpResponseMessage? response)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
        }
        //public async Task<IActionResult> Logout()
        //{
        //    Response.Cookies.Delete("UserName");
        //    Response.Cookies.Delete("Role");
        //    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Login", "Login");
        //}

    }
}
