using System;
using System.Collections.Generic;
using System.Text;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.DTO;
using TicketEShop.Services.Interface;
using TicketEShop.Repository.Interface;
using System.Linq;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Services.Implementation
{
    public class MovieTicketService : IMovieTicketService
    {

        private readonly IRepository<MovieTicket> _movieTicketRepository;
        private readonly IRepository<MovieTicketInShoppingCart> _movieTicketInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public MovieTicketService(IRepository<MovieTicket> movieTicketRepository, IRepository<MovieTicketInShoppingCart> movieTicketInShoppingCartRepository, IUserRepository userRepository)
        {
            _movieTicketRepository = movieTicketRepository;
            _movieTicketInShoppingCartRepository = movieTicketInShoppingCartRepository;
            _userRepository = userRepository;
        }
        
        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {

            var user = this._userRepository.Get(userID);

            var userShoppingCart = user.UserCart;

            if (item.SelectedMovieTicketId != null && userShoppingCart != null)
            {
                var movieTicket = this.GetDetailsForMovieTicket(item.SelectedMovieTicketId);


                if (movieTicket != null)
                {
                    MovieTicketInShoppingCart itemToAdd = new MovieTicketInShoppingCart
                    {
                        MovieTicket = movieTicket,
                        MovieTicketId = movieTicket.Id,
                        ShoppingCart = userShoppingCart,
                        ShoppingCartId = userShoppingCart.Id,
                        Quantity = item.Quantity
                    };

                    this._movieTicketInShoppingCartRepository.Insert(itemToAdd);

                    return true;
                }

                return false;
            }
            return false;
        }

        public void CreateNewMovieTicket(MovieTicket p)
        {
            this._movieTicketRepository.Insert(p);
        }

        public void DeleteMovieTicket(Guid id)
        {
            var movieTicket = this.GetDetailsForMovieTicket(id);
            this._movieTicketRepository.Delete(movieTicket);
        }

        public List<MovieTicket> GetAllMovieTickets()
        {
            return this._movieTicketRepository.GetAll().ToList();
        }

        public MovieTicket GetDetailsForMovieTicket(Guid? id)
        {
            return this._movieTicketRepository.Get(id);
        }

        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var movieTicket = this.GetDetailsForMovieTicket(id);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedMovieTicket = movieTicket,
                SelectedMovieTicketId = movieTicket.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdeteExistingMovieTicket(MovieTicket p)
        {
            this._movieTicketRepository.Update(p);
        }
    }
}
