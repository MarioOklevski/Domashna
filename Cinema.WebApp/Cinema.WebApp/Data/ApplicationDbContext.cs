using Cinema.WebApp.Models.Domain;
using Cinema.WebApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<CinemaAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<MovieInShoppingCart> MovieInShoppingCarts { get; set; }

protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Movie>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<MovieInShoppingCart>()
                .HasKey(z => new { z.MovieId, z.ShoppingCartId });

            builder.Entity<MovieInShoppingCart>()
                .HasOne(z => z.Movie)
                .WithMany(z => z.MovieInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<MovieInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.MovieInShoppingCarts)
                .HasForeignKey(z => z.MovieId);


            builder.Entity<ShoppingCart>()
                .HasOne<CinemaAppUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);
        }
    }
}
