using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vinapp.Api.Dto;
using Vinapp.Api.Services;
#pragma warning disable 1591

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

        /// <summary>
        /// Provides all tickets for the provided {week}
        /// </summary>
        /// <param name="week"></param>
        /// <returns>Collections of LotteryTicketDto</returns>
        /// <response code="200">Collections of LotteryTicketDto</response>
        /// <response code="400">If params {week} is null</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<LotteryTicketDto>), 200)]
        [ProducesResponseType(typeof(IEnumerable<LotteryTicketDto>), 400)]
        public async Task<IActionResult> Get([FromQuery]int week)
        {
            if (week < 1 || week > 53)
            {
                return BadRequest("Please provide a valid week number");
            }

            var tickets = await _lotteryTicketService.GetTicketsByWeek(week);
            return Ok(tickets);
        }

        /// <summary>
        /// Placing a ticket. TicketNumber and week are mandatory
        /// </summary>
        /// <param name="ticketDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete ticket by ticketnumber.
        /// </summary>
        /// <remarks>Not implemented yet!</remarks>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete()
        {
            return NoContent();
        }
    }
}
