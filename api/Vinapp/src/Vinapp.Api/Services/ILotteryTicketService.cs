using System.Collections.Generic;
using System.Threading.Tasks;
using Vinapp.Api.Dto;

namespace Vinapp.Api.Services
{
    public interface ILotteryTicketService
    {
        Task SaveTicket(LotteryTicketDto ticketDto);

        Task<IEnumerable<LotteryTicketDto>> GetTicketsByWeek(int week);
    }
}