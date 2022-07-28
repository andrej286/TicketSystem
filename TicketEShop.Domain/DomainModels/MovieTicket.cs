using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Domain.DomainModels
{
    public class MovieTicket : BaseEntity
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string MovieImage { get; set; }
        [Required]
        public int TicketPrice { get; set; }
        [Required]
        public DateTime WatchDate { get; set; }
        public virtual ICollection<MovieTicketInShoppingCart> MovieTicketInShoppingCart { get; set; }

        public virtual ICollection<MovieTicketInOrder> MovieTicketInOrders { get; set; }

        public MovieTicket() { }
    }
}
