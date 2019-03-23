using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TexasPetroleum.Models;

namespace TexasPetroleum
{
    public class QuoteContext : DbContext
    {
        public QuoteContext() : base("name=sdSingh")
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<FuelQuote> Quotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(x => x.ClientId);

            modelBuilder.Entity<Client>()
                .HasRequired(m => m.Address)
                .WithRequiredPrincipal(x => x.Client)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Client>()
                .HasMany(x => x.FuelQuotes)
                .WithRequired(x => x.Client)
                .WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }
    }
}