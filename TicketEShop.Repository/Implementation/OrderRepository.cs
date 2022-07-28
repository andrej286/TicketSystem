using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketEShop.Domain;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Repository.Interface;

namespace TicketEShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> getAllOrders()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.MovieTicketInOrders)
                .Include("MovieTicketInOrders.MovieTicket")
                .ToListAsync().Result;
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return entities
               .Include(z => z.User)
               .Include(z => z.MovieTicketInOrders)
               .Include("MovieTicketInOrders.MovieTicket")
               .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}
