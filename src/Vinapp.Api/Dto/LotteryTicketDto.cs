using System.ComponentModel.DataAnnotations;
using Vinapp.Api.Controllers;
#pragma warning disable 1591

namespace Vinapp.Api.Dto
{
    public class LotteryTicketDto
    {
        [Required(ErrorMessage = "Please provide a ticket number")]
        public string TicketNumber { get; set; }

        [Required(ErrorMessage = "Please provide a week number")]
        public int Week { get; set; }

        public string Username { get; set; }
    }
}