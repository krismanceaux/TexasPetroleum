namespace TexasPetroleum
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuoteContext : DbContext
    {
        public QuoteContext()
            : base("name=sdSingh")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<FuelQuote> FuelQuotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuelQuote>()
                .Property(f => f.DeliveryDate)
                .HasColumnType("datetime2");
            modelBuilder.Entity<FuelQuote>()
                .Property(f => f.TimeCreated)
                .HasColumnType("datetime2");
        }
    }   
}