using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.Identity;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<TicketEShopApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MovieTicket> MovieTickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<MovieTicketInShoppingCart> MovieTicketInShoppingCarts { get; set; }
        public virtual DbSet<MovieTicketInOrder> MovieTicketInOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MovieTicket>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            //builder.Entity<MovieTicketInShoppingCart>()
            //    .HasKey(z => new { z.MovieTicketId, z.ShoppingCartId });

            builder.Entity<MovieTicketInShoppingCart>()
                .HasOne(z => z.MovieTicket)
                .WithMany(z => z.MovieTicketInShoppingCart)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<MovieTicketInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.MovieTicketInShoppingCart)
                .HasForeignKey(z => z.MovieTicketId);

            builder.Entity<ShoppingCart>()
                .HasOne<TicketEShopApplicationUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);

            //builder.Entity<MovieTicketInOrder>()
            //   .HasKey(z => new { z.MovieTicketId, z.OrderId });


            builder.Entity<MovieTicketInOrder>()
                .HasOne(z => z.MovieTicket)
                .WithMany(z => z.MovieTicketInOrders)
                .HasForeignKey(z => z.MovieTicketId);

            builder.Entity<MovieTicketInOrder>()
                .HasOne(z => z.Order)
                .WithMany(z => z.MovieTicketInOrders)
                .HasForeignKey(z => z.OrderId);
        }
    }
}
