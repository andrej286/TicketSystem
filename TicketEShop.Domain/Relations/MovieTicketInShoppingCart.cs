using System;
using TicketEShop.Domain.DomainModels;

namespace TicketEShop.Domain.Relations
{
    public class MovieTicketInShoppingCart : BaseEntity
    {
        public Guid MovieTicketId { get; set; }
        public MovieTicket MovieTicket { get; set; }
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int Quantity { get; set; }
    }
}
