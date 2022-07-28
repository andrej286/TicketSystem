using System;
using System.Collections.Generic;
using System.Text;
using TicketEShop.Domain.DTO;

namespace TicketEShop.Services.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteMovieTicketFromSoppingCart(string userId, Guid movieTicketId);
        bool order(string userId);
    }
}