using System;
using System.Collections.Generic;
using System.Text;
using TicketEShop.Domain;
using TicketEShop.Domain.DomainModels;

namespace TicketEShop.Repository.Interface
{
    public interface IOrderRepository
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);

    }
}
