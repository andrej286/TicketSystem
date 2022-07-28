using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketEShop.Domain.DomainModels;

namespace TicketEShop.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public MovieTicket SelectedMovieTicket { get; set; }
        public Guid SelectedMovieTicketId { get; set; }
        public int Quantity { get; set; }
    }
}