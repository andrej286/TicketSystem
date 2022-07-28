using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.DTO;
using TicketEShop.Domain.Relations;
using TicketEShop.Repository.Interface;
using TicketEShop.Services.Interface;

namespace TicketEShop.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {

        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<MovieTicketInOrder> _movieTicketInOrderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<EmailMessage> _mailRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository, IRepository<Order> orderRepository, IRepository<MovieTicketInOrder> movieTicketInOrderRepository, IRepository<EmailMessage> mailRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _movieTicketInOrderRepository = movieTicketInOrderRepository;
            _mailRepository = mailRepository;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var allMovieTickets = userShoppingCart.MovieTicketInShoppingCart.ToList();

                var allMovieTicketPrice = allMovieTickets.Select(z => new
                 {
                     movieTicketPrice = z.MovieTicket.TicketPrice,
                     Quantity = z.Quantity
                 }).ToList();

                 double totalPrice = 0;

                 foreach (var item in allMovieTicketPrice)
                 {
                     totalPrice += item.movieTicketPrice * item.Quantity;
                 }

                 ShoppingCartDto shoppingCartDtoitem = new ShoppingCartDto
                 {
                      MovieTickets = allMovieTickets,
                      TotalPrice = totalPrice
                 };

                 return shoppingCartDtoitem;
            }
            return new ShoppingCartDto();
        }

        public bool deleteMovieTicketFromSoppingCart(string userId, Guid movieticketid)
        {
            if (!string.IsNullOrEmpty(userId) && movieticketid != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.MovieTicketInShoppingCart.Where(z => z.MovieTicketId.Equals(movieticketid)).FirstOrDefault();

                userShoppingCart.MovieTicketInShoppingCart.Remove(itemToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);

                return true;
            }
            return false;
        }

        public bool order(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);
                var userCard = loggedInUser.UserCart;

                EmailMessage message = new EmailMessage();
                message.MailTo = loggedInUser.Email;
                message.Subject = "Order was successful";
                message.Status = false;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepository.Insert(order);

                List<MovieTicketInOrder> productInOrders = new List<MovieTicketInOrder>();

                var result = userCard.MovieTicketInShoppingCart.Select(z => new MovieTicketInOrder
                {
                    Id = Guid.NewGuid(),
                    MovieTicketId = z.MovieTicket.Id,
                    MovieTicket = z.MovieTicket,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = z.Quantity,
                }).ToList();

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Your order is complet. The order contains: ");

                var totalPrice = 0.0;

                for (int i = 1; i < result.Count(); i++)
                {
                    var item = result[i-1];
                    totalPrice += item.Quantity * item.MovieTicket.TicketPrice;
                    sb.AppendLine(i.ToString() + "_" + item.MovieTicket.MovieName + " with price of: " + item.MovieTicket.TicketPrice + " and quantity of: " + item.Quantity);

                }

                sb.AppendLine("Total Price: " + totalPrice.ToString());

                message.Content = sb.ToString();

                productInOrders.AddRange(result);

                foreach (var item in productInOrders)
                {
                    this._movieTicketInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.MovieTicketInShoppingCart.Clear();

                this._mailRepository.Insert(message);

                this._userRepository.Update(loggedInUser);

                return true;
            }
            return false;
        }
    }
}
