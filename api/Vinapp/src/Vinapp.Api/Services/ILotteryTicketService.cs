using System.Threading.Tasks;
using Vinapp.Api.Dto;

namespace Vinapp.Api.Services
{
    public interface ILotteryTicketService
    {
        Task SaveTicket(LotteryTicketDto ticketDto);
    }
}
