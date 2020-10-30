using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_ЖД_вокзала_N__кассир_
{
    public enum TicketType
    {
        Coupe,
        Reserved
    }
    public enum Status
    {
        Sold,
        For_Sale
    }
    class Ticket
    {
        private string route_;
        private TicketType ticketType_;
        private Status status_;
        public Ticket(string route, TicketType ticketType, Status status)
        {
            route_ = route;
            ticketType_ = ticketType;
            status_ = status;
        }

    }
}
