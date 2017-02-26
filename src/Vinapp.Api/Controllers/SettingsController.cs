using Microsoft.AspNetCore.Mvc;

namespace Vinapp.Api.Controllers
{
    /// <summary>
    /// Endpoint for providing configuration values
    /// </summary>
    [Route("api/[controller]")]
    public class SettingsController : Controller
    {
        /// <summary>
        /// Provides possible tickets to use at any moment
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Object</response>
        [HttpGet("ticketsToUse")]
        [ProducesResponseType(typeof(object), 200)]
        public IActionResult TicketsToUse()
        {
            return Ok(new {Amount = 100});
        }
    }
}