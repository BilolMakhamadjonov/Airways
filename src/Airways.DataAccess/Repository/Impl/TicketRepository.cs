using Airways.Core.Entities;
using Airways.DataAccess.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airways.DataAccess.Repository.Impl
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        private readonly DatabaseContext dataBaseContext;
        public TicketRepository(DatabaseContext context) : base(context)
        {
            dataBaseContext = context;
        }
        public Ticket GetTicketById(Guid ticketId)
        {
            return dataBaseContext.Tickets.FirstOrDefault(t => t.Id == ticketId);
        }

        public Ticket OrderCancellation(Guid id)
        {
            var ticket = GetTicketById(id);

            if (ticket == null) return null;

            ticket.status = Status.Available;
            ticket.UserId = null;

            dataBaseContext.SaveChanges();

            return ticket;
        }
    }
}
