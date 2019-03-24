namespace TexasPetroleum
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=QuoteContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<FuelQuote> FuelQuotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasOptional(e => e.Address)
                .WithRequired(e => e.Client);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.FuelQuotes)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.Client_ClientID)
                .WillCascadeOnDelete();
        }
    }
}
