using System.Collections.Generic;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<MovieTicketInShoppingCart> MovieTickets { get; set; }

        public double TotalPrice { get; set; }
    }
}
