using System.ComponentModel.DataAnnotations;

namespace Vinapp.Api.Dto
{
    public class LotteryTicketDto
    {
        [Required(ErrorMessage = "Please provide a ticket number")]
        public string TicketNumber { get; set; }

        [Required(ErrorMessage = "Please provide a week number")]
        public int Week { get; set; }
    }
}