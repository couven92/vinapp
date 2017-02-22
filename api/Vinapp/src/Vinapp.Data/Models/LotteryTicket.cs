using System;

namespace Vinapp.Data.Models
{
    public class LotteryTicket
    {
        public int TicketId { get; set; }

        public string TicketNumber { get; set; }

        public int Week { get; set; }

        public bool IsPaid { get; set; }

        public bool IsWinnerTicket { get; set; }

        public DateTime? Purchased { get; set; }

        public DateTime? RowUpdated { get; set; }

        public byte[] RowVersion { get; set; }
    }
}