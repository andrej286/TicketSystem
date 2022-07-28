using System;
using System.Collections.Generic;
using System.Text;
using TicketEShop.Domain.Identity;

namespace TicketEShop.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<TicketEShopApplicationUser> GetAll();
        TicketEShopApplicationUser Get(string id);
        void Insert(TicketEShopApplicationUser entity);
        void Update(TicketEShopApplicationUser entity);
        void Delete(TicketEShopApplicationUser entity);
    
    }
}
