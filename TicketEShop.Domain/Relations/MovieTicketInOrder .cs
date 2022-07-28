using System;
using TicketEShop.Domain.DomainModels;

namespace TicketEShop.Domain.Relations
{
    public class MovieTicketInOrder : BaseEntity
    {
        public Guid MovieTicketId { get; set; }
        public MovieTicket MovieTicket { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}
