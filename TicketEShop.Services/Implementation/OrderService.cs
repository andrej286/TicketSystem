using System;
using System.Collections.Generic;
using System.Text;
using TicketEShop.Domain;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Repository.Interface;
using TicketEShop.Services.Interface;

namespace TicketEShop.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> getAllOrders()
        {
            return this._orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return this._orderRepository.getOrderDetails(model);
        }
    }
}
