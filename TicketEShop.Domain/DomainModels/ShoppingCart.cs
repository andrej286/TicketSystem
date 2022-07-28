using System;
using System.Collections.Generic;
using TicketEShop.Domain.Identity;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }

        public TicketEShopApplicationUser Owner { get; set; }

        public virtual ICollection<MovieTicketInShoppingCart> MovieTicketInShoppingCart { get; set; }
    
    }
}