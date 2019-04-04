namespace TexasPetroleum
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuoteContext : DbContext
    {
        public QuoteContext()
            : base("name=QuoteContext")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientLogin> ClientLogins { get; set; }
        public virtual DbSet<FuelQuote> FuelQuotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.FuelQuotes)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClientLogin>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.ClientLogin)
                .HasForeignKey(e => e.LoginId)
                .WillCascadeOnDelete(false);
        }
    }
}
