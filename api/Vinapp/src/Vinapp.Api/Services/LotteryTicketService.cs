using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinapp.Api.Dto;
using Vinapp.Data.Dal;
using Vinapp.Data.Models;

namespace Vinapp.Api.Services
{
    public class LotteryTicketService : ILotteryTicketService
    {
        private readonly ILotteryTicketRepository _lotteryTicketRepository;

        public LotteryTicketService(ILotteryTicketRepository lotteryTicketRepository)
        {
            _lotteryTicketRepository = lotteryTicketRepository;
        }

        public async Task SaveTicket(LotteryTicketDto ticketDto)
        {
            var ticket = await _lotteryTicketRepository.Get(ticketDto.TicketNumber, ticketDto.Week);

            if (ticket == null)
            {
                var ticketModel = new LotteryTicket
                {
                    IsPaid = false,
                    IsWinnerTicket = false,
                    Purchased = DateTime.UtcNow,
                    Week = ticketDto.Week,
                    TicketNumber = ticketDto.TicketNumber,
                    RowUpdated = DateTime.UtcNow
                };

                await _lotteryTicketRepository.Insert(ticketModel);
            }
            else
            {
                ticket.IsPaid = ticket.IsPaid;
                ticket.IsWinnerTicket = ticket.IsWinnerTicket;
                ticket.RowUpdated = DateTime.UtcNow;

                await _lotteryTicketRepository.Update(ticket);
            }
        }

        public async Task<IEnumerable<LotteryTicketDto>> GetTicketsByWeek(int week)
        {
            var tickets = await _lotteryTicketRepository.GetAllByWeek(week);
            return tickets.Select(ToLotteryTicketsDto);
        }

        private static LotteryTicketDto ToLotteryTicketsDto(LotteryTicket ticket)
        {
            return new LotteryTicketDto
            {
                Week = ticket.Week,
                TicketNumber = ticket.TicketNumber
            };
        }
    }
}
