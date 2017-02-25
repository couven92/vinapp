using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vinapp.Api.Dto;
using Vinapp.Api.Services;

namespace Vinapp.Api.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        private readonly ILotteryTicketService _lotteryTicketService;

        public TicketsController(ILotteryTicketService lotteryTicketService)
        {
            _lotteryTicketService = lotteryTicketService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(int week)
        {
            if (week < 1 || week > 53)
            {
                return BadRequest("Please provide a valid week number");
            }

            var tickets = await _lotteryTicketService.GetTicketsByWeek(week);
            return Ok(tickets);
        }

        [HttpPost("purchaseTicket")]
        public async Task<IActionResult> PurchaseTicket([FromBody]LotteryTicketDto ticketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please make sure all fields are properly supplied");
            }

            await _lotteryTicketService.SaveTicket(ticketDto);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}
