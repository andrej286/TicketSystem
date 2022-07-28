using Microsoft.AspNetCore.Identity;
using TicketEShop.Domain.DomainModels;

namespace TicketEShop.Domain.Identity
{
    public class TicketEShopApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public virtual ShoppingCart UserCart { get; set; }
    }
}
