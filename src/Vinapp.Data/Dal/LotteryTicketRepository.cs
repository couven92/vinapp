using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vinapp.Data.Models;

namespace Vinapp.Data.Dal
{
    public class LotteryTicketRepository : ILotteryTicketRepository
    {
        private readonly VinappContext _vinappContext;

        public LotteryTicketRepository(VinappContext vinappContext)
        {
            _vinappContext = vinappContext;
        }

        public async Task<LotteryTicket> Get(string ticketNumber, int week)
        {
            return
                await _vinappContext.LotteryTickets.Where(x => x.Week == week && x.TicketNumber == ticketNumber)
                    .FirstOrDefaultAsync();
        }

        public async Task Update(LotteryTicket ticket)
        {
            _vinappContext.Entry(ticket).State = EntityState.Modified;
            await _vinappContext.SaveChangesAsync();
        }

        public async Task Insert(LotteryTicket ticket)
        {
            _vinappContext.LotteryTickets.Add(ticket);
            await _vinappContext.SaveChangesAsync();
        }

        public async Task Delete(LotteryTicket ticket)
        {
            _vinappContext.Remove(ticket);
            await _vinappContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<LotteryTicket>> GetAllByWeek(int week)
        {
            return await _vinappContext.LotteryTickets.Where(x => x.Week == week).ToListAsync();
        }
    }
}
