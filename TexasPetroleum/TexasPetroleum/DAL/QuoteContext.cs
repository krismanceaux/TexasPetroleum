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
        public QuoteContext() : base("QuoteContext")
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<FuelQuote> Quotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}