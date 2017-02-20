using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vinapp.Api.Controllers
{
    public class TicketsController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Save()
        {
            return NoContent();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}
