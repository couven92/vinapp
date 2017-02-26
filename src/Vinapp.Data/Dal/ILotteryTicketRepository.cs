using System.Collections.Generic;
using System.Threading.Tasks;
using Vinapp.Data.Models;

namespace Vinapp.Data.Dal
{
    public interface ILotteryTicketRepository
    {
        Task Delete(LotteryTicket ticket);

        Task Insert(LotteryTicket ticket);

        Task Update(LotteryTicket ticket);

        Task<LotteryTicket> Get(string ticketNumber, int week);

        Task<IEnumerable<LotteryTicket>> GetAllByWeek(int week);
    }
}