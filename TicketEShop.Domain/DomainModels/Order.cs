using System;
using System.Collections.Generic;
using TicketEShop.Domain.Identity;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public TicketEShopApplicationUser User { get; set; }

        public virtual ICollection<MovieTicketInOrder> MovieTicketInOrders { get; set; }
    }
}
