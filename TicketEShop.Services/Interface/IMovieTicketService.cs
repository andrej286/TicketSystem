using System;
using System.Collections.Generic;
using System.Text;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.DTO;

namespace TicketEShop.Services.Interface
{
    public interface IMovieTicketService
    {
        List<MovieTicket> GetAllMovieTickets();
        MovieTicket GetDetailsForMovieTicket(Guid? id);
        void CreateNewMovieTicket(MovieTicket p);
        void UpdeteExistingMovieTicket(MovieTicket p);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
        void DeleteMovieTicket(Guid id);
        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}
