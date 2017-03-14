using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using static Newtonsoft.Json.JsonConvert;

namespace Vinapp.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
        {
            if (HttpContext.User == null || !HttpContext.User.Identity.IsAuthenticated)
                await HttpContext.Authentication.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/" });

            return View("Index");
        }

        public async Task<JsonResult> GetToken()
        {
            //Auth auth = await GetTokenAsync(HttpContext.User.Identity.Name)
            Auth auth = await GetTokenAsync("Njaal", "P@ssw0rd!");

            return Json(auth);
        }

        public IActionResult Error()
        {
            return View();
        }

        private static async Task<Auth> GetTokenAsync(string username, string password = "")
        {
            const string path = "api/auth/token";
            var client = new HttpClient {BaseAddress = new Uri("http://localhost:9888/")};

            var login = new Login
            {
                Username = username,
                Password = password
            };

            var stringPayload = await Task.Run(() => SerializeObject(login));


            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(path, httpContent);
            if (!response.IsSuccessStatusCode) return null;
            if (response.Content != null)
                return
                    await await Task.Factory.StartNew(async () => DeserializeObject<Auth>(await response.Content.ReadAsStringAsync()));
            return null;
        }
    }
}
