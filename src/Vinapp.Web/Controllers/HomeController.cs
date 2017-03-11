using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Cli.Utils;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Vinapp.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
        {
            var token = "";
            if (HttpContext.User == null || !HttpContext.User.Identity.IsAuthenticated)
                HttpContext.Authentication.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/" });
            //if (HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated)
            //{
                

            //}
            Auth something = await GetTokenAsync("Njaal", "P@ssw0rd!");
            token = something.Token;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        static async Task<Auth> GetTokenAsync(string username, string password)
        {
            var path = "api/auth/token";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9888/");

            var login = new Login
            {
                Username = username,
                Password = password
            };

            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(login));


            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            Auth Auth = null;

            HttpResponseMessage response = await client.PostAsync(path, httpContent);
            if (response.IsSuccessStatusCode)
            {
                //return await response.Content.ReadAsAsync<Auth>().ConfigureAwait(false);
                if (response.Content != null)
                    return await JsonConvert.DeserializeObjectAsync<Auth>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}
