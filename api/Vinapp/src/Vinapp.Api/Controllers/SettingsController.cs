using Microsoft.AspNetCore.Mvc;

namespace Vinapp.Api.Controllers
{
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {
        [HttpGet("ticketsToUse")]
        public IActionResult TicketsToUse()
        {
            return Ok(new {Amount = 100});
        }
    }
}