using System;
using System.Collections.Generic;
using System.Text;
using TicketEShop.Domain;
using TicketEShop.Domain.DomainModels;

namespace TicketEShop.Services.Interface
{
    public interface IOrderService
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}